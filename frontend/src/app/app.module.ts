import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SubjectComponent } from './components/registers/subject/subject.component';
import { SubjectlistComponent } from './components/lists/subjectlist/subjectlist.component';
import { AuthorlistComponent } from './components/lists/authorlist/authorlist.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { AuthorComponent } from './components/registers/author/author.component';
import { BookComponent } from './components/registers/book/book.component';
import { BooklistComponent } from './components/lists/booklist/booklist.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

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
    HttpClientModule,
    ReactiveFormsModule,
    CommonModule,
    FormsModule,
    NgbModule
  ],
  providers: [HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
