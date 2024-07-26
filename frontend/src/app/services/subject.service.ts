import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Subject } from '../interfaces/subject';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {

  baseUrl: string = 'http://localhost:5172/api/subject/';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Subject[]> {
    return this.http.get<Subject[]>(this.baseUrl);
  }

  get(id: number): Observable<Subject> {
    var url = this.baseUrl + id;
    return this.http.get<Subject>(url);
  }

  post(assunto: Subject): Observable<Subject> {
    return this.http.post<Subject>(this.baseUrl, assunto);
  }

  put(id: number, assunto: Subject): Observable<Subject> {
    var url = this.baseUrl + id;
    return this.http.put<Subject>(url, assunto);
  }

  delete(id: number): Observable<any> {
    var url: string = this.baseUrl + id;
    return this.http.delete(url);
  }
}
