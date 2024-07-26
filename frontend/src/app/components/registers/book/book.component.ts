import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Author } from 'src/app/interfaces/author';
import { Book } from 'src/app/interfaces/book';
import { Subject } from 'src/app/interfaces/subject';
import { AuthorService } from 'src/app/services/author.service';
import { BookService } from 'src/app/services/book.service';
import { SubjectService } from 'src/app/services/subject.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent {

  public livro!: Book;
  public autor!: Author[];
  public assunto!: Subject[];

  constructor(private bookService: BookService, private authorService: AuthorService, private subjectService: SubjectService, private router: Router) { }

ngOnInit(){
  this.getListSubject();
  this.getListAuthor();
}

  getListAuthor() {
    this.authorService.getAll().subscribe({
      next: (response: Author[]) => {
        console.log('response===>', response);
        this.autor = response;
      },
      error: (error: any) => {
        console.log('error===>', error);
      },
      complete: () => {  }
    });
  }

  getListSubject() {
    this.subjectService.getAll().subscribe({
      next: (response: Subject[]) => {
        console.log('response===>', response);
        this.assunto = response;
      },
      error: (error: any) => {
        console.log('error===>', error);
      },
      complete: () => {  }
    });
  }

  save(book: NgForm) {
    this.bookService.post(book.value).subscribe({
      next: (response: Book) => {
        console.log('Salvo!!===>', response);
        this.livro = response;
        this.router.navigateByUrl("/booklist")
      },
      error: (error: any) => {
        console.log('error===>', error);
      },
      complete: () => { }
    });
  }
}