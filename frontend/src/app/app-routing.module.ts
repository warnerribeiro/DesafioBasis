import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SubjectComponent } from './registers/subject/subject.component';
import { SubjectlistComponent } from './lists/subjectlist/subjectlist.component';
import { AuthorlistComponent } from './lists/authorlist/authorlist.component';
import { BooklistComponent } from './lists/booklist/booklist.component';
import { AuthorComponent } from './registers/author/author.component';
import { BookComponent } from './registers/book/book.component';

const routes: Routes = [
    {path: 'authorlist',  component: AuthorlistComponent},
    {path: 'booktlist',  component: BooklistComponent},
    {path: 'subjectlist',  component: SubjectlistComponent},
    {path: 'author',  component: AuthorComponent},
    {path: 'subject',  component: SubjectComponent},
    {path: 'book',  component: BookComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
