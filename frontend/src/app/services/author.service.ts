import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Author } from '../interfaces/author';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {

  baseUrl: string = 'http://localhost:5172/api/author/';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Author[]> {
    return this.http.get<Author[]>(this.baseUrl);
  }

  get(id: number): Observable<Author> {
    var url = this.baseUrl + id;
    return this.http.get<Author>(url);
  }

  post(assunto: Author): Observable<Author> {
    return this.http.post<Author>(this.baseUrl, assunto);
  }

  put(id: number, assunto: Author): Observable<Author> {
    var url = this.baseUrl + id;
    return this.http.put<Author>(url, assunto);
  }

  delete(id: number): Observable<any> {
    var url: string = this.baseUrl + id;
    return this.http.delete(url);
  }
}
