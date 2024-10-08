import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Author } from 'src/app/interfaces/author';
import { Book } from 'src/app/interfaces/book';
import { AuthorService } from 'src/app/services/author.service';

@Component({
  selector: 'app-authorlist',
  templateUrl: './authorlist.component.html',
  styleUrls: ['./authorlist.component.css']
})
export class AuthorlistComponent {
  public loading!: boolean;
  public autor!: Author[];
  /**
   *
   */
  constructor(private authorService: AuthorService, private router: Router) { }

  ngOnInit(): void {
    this.getList();
  }

  getList() {
    this.loading = true;
    console.time('GetAll Author');
    this.authorService.getAll().subscribe({
      next: (response: Author[]) => {
        //console.log('Get', response);
        this.autor = response;
      },
      error: (error: any) => {
        console.log('GetAll Authors Error ==>', error);
      },
      complete: () => { this.loading = false; console.table(this.autor);  console.timeEnd('GetAll Author'); }
    });
    
  }

  delete(id: number) {
    this.authorService.delete(id).subscribe({
      next: (response: Author[]) => {
        console.log('delete===>', response);
      },
      error: (error: any) => {
        console.log('delteerror===>', error);
      },
      complete: () => { this.getList(); }
    });
  }

  update(id: number) {
    this.router.navigateByUrl("/author/" + id)
  }
}
