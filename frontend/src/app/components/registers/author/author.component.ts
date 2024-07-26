import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Author } from 'src/app/interfaces/author';
import { AuthorService } from 'src/app/services/author.service';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent {
  public autor!: Author;

  constructor(private authorService: AuthorService, private router: Router) { }

  save(author: NgForm) {
    this.authorService.post(author.value).subscribe({
      next: (response: Author) => {
        console.log('Salvo!!===>', response);
        this.autor = response;
        this.router.navigateByUrl("/authorlist")
      },
      error: (error: any) => {
        console.log('error===>', error);
      },
      complete: () => { }
    });
  }
}
