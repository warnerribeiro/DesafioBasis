import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Assunto } from '../interfaces/assunto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {

  baseUrl: string = 'http://localhost:5172/api/subject';

  constructor(private http: HttpClient) { }

  getAll():Observable<Assunto[]> {
    return this.http.get<Assunto[]>(this.baseUrl);
  }
}
