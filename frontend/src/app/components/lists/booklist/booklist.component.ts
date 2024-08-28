import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Book } from 'src/app/interfaces/book';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-booklist',
  templateUrl: './booklist.component.html',
  styleUrls: ['./booklist.component.css']
})
export class BooklistComponent {
  public loading!: boolean;
  public livro!: Book[];

  /**
   *
   */
  constructor(private bookService: BookService, private router: Router) { }

  ngOnInit(): void {
    this.getList();
  }

  getList() {
    this.loading = true;
    this.bookService.getAll().subscribe({
      next: (response: Book[]) => {
        this.livro = response;
      },
      error: (error: any) => {
        console.log('error===>', error);
      },
      complete: () => { this.loading = false }
    });
  }

  delete(id: number) {
    this.bookService.delete(id).subscribe({
      next: (response: Book[]) => {
      },
      error: (error: any) => {
        console.log('delete error===>', error);
      },
      complete: () => { this.getList(); }
    });
  }

  update(id: number) {
    this.router.navigateByUrl("/book/" + id)
  }
}
