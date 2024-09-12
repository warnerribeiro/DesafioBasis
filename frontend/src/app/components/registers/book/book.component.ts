import { Component, inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Author } from 'src/app/interfaces/author';
import { Book } from 'src/app/interfaces/book';
import { BookValue } from 'src/app/interfaces/bookvalue';
import { Origin } from 'src/app/interfaces/origin';
import { Subject } from 'src/app/interfaces/subject';
import { AuthorService } from 'src/app/services/author.service';
import { BookService } from 'src/app/services/book.service';
import { OriginService } from 'src/app/services/origin.service';
import { SubjectService } from 'src/app/services/subject.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent {
  private readonly formBuilder = inject(FormBuilder);
  private readonly bookService = inject(BookService);
  private readonly authorService = inject(AuthorService);
  private readonly subjectService = inject(SubjectService);
  private readonly originService = inject(OriginService);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);

  private id!: number;
  public livro!: Book;
  public autor!: Author[];
  public assunto!: Subject[];
  public origin!: Origin[];
  public bookvalue: BookValue[] = [];

  protected form: any = this.formBuilder.group(
    {
      title: this.formBuilder.control('', {
        validators: [Validators.required],
        nonNullable: true
      }),
      publisher: this.formBuilder.control('', {
        validators: [Validators.required],
        nonNullable: true
      }),
      edition: this.formBuilder.control('', {
        validators: [Validators.required],
        nonNullable: true
      }),
      yearOfPublication: this.formBuilder.control('', {
        validators: [Validators.required,],
        nonNullable: true
      }),
      bookAuthor: this.formBuilder.control('', {
        validators: [Validators.required],
        nonNullable: true
      }),
      bookSubject: this.formBuilder.control('', {
        validators: [Validators.required],
        nonNullable: true
      }),
      origin: this.formBuilder.control('', {
      }),
      value: this.formBuilder.control('', {
      }),
    }
  );

  ngOnInit() {
    this.getListOrigin();
    this.getListSubject();
    this.getListAuthor();

    const id = Number(this.route.snapshot.paramMap.get('id'));

    if (id) {
      this.bookService.get(id).subscribe({
        next: (response: Book) => {
          this.id = response.bookId ?? 0;
          this.form.get('title')?.setValue(response.title);
          this.form.get('publisher')?.setValue(response.publisher);
          this.form.get('edition')?.setValue(response.edition);
          this.form.get('yearOfPublication')?.setValue(response.yearOfPublication);
          this.form.get('bookAuthor')?.setValue(response.bookAuthor.map(a => a.authorId.toString()));
          this.form.get('bookSubject')?.setValue(response.bookSubject.map(a => a.subjectId.toString()));
          this.bookvalue = response.bookValue;
        },
        error: (error: any) => {
          console.log('Error getting the author!', error);
        },
        complete: () => { }
      });
    }
  }

  getListAuthor() {
    this.authorService.getAll().subscribe({
      next: (response: Author[]) => {
        this.autor = response;
      },
      error: (error: any) => {
        console.log('Error getting the author!', error);
      },
      complete: () => { }
    });
  }

  getListOrigin() {
    this.originService.getAll().subscribe({
      next: (response: Origin[]) => {
        this.origin = response;
      },
      error: (error: any) => {
        console.log('Error getting the origin!', error);
      },
      complete: () => { }
    });
  }

  getListSubject() {
    this.subjectService.getAll().subscribe({
      next: (response: Subject[]) => {
        this.assunto = response;
      },
      error: (error: any) => {
        console.log('Error getting the subject!', error);
      },
      complete: () => { }
    });
  }

  onSubmit() {
    var book: Book = {
      bookId: this.id,
      title: this.form.value.title,
      publisher: this.form.value.publisher,
      edition: this.form.value.edition,
      yearOfPublication: this.form.value.yearOfPublication.toString(),
      bookAuthor: this.form.value.bookAuthor.map((i: number) => ({
        authorId: +i,
        bookId: this.id
      })),
      bookSubject: this.form.value.bookSubject.map((i: number) => ({
        subjectId: +i,
        bookId: this.id
      })),
      bookValue: this.bookvalue,
    }

    if (this.id) {
      this.update(book);
    } else {
      this.add(book);
    }
  }

  add(book: Book) {
    this.bookService.post(book).subscribe({
      next: (response: Book) => {
        console.log('Book salved!', response);
        this.livro = response;
        this.router.navigateByUrl("/booklist")
      },
      error: (error: any) => {
        console.log('Error saving the book!', error);
      },
      complete: () => { }
    });
  }

  update(book: Book) {
    this.bookService.put(this.id, book).subscribe({
      next: (response: Book) => {
        console.log('Book updated!', response);
        this.livro = response;
        this.router.navigateByUrl("/booklist")
      },
      error: (error: any) => {
        console.log('Error updating the book', error);
      },
      complete: () => { }
    });
  }

  addOriginValue() {

    var name = this.origin.filter(a => a.originPurchaseId == this.form.value.origin)[0].name;

    var bookvalue: BookValue = {
      bookId: this.id ?? 0,
      originPurchaseId: this.form.value.origin,
      originName: name,
      value: this.form.value.value
    }

    var exist = this.bookvalue.filter(a => a.originPurchaseId == this.form.value.origin);

    if (!exist.length) {
      this.bookvalue.push(bookvalue);
    }
  }

  removeOriginValue(id: number) {

    var remove = this.bookvalue.filter(a => a.originPurchaseId == id)[0];

    const index = this.bookvalue.indexOf(remove, 0);
    if (index > -1) {
      this.bookvalue.splice(index, 1);
    }
  }
}