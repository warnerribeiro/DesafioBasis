import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SubjectComponent } from './registers/subject/subject.component';
import { SubjectlistComponent } from './lists/subjectlist/subjectlist.component';
import { AuthorlistComponent } from './lists/authorlist/authorlist.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { AuthorComponent } from './registers/author/author.component';
import { BookComponent } from './registers/book/book.component';
import { BooklistComponent } from './lists/booklist/booklist.component';

@NgModule({
  declarations: [
    AppComponent,
    SubjectComponent,
    SubjectlistComponent,
    AuthorlistComponent,
    AuthorComponent,
    BookComponent,
    BooklistComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
