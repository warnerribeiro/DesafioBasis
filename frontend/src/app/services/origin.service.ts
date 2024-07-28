import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Origin } from '../interfaces/origin';

@Injectable({
  providedIn: 'root'
})
export class OriginService {
  baseUrl: string = 'http://localhost:5172/api/originpurchase/';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Origin[]> {
    return this.http.get<Origin[]>(this.baseUrl);
  }

  get(id: number): Observable<Origin> {
    var url = this.baseUrl + id;
    return this.http.get<Origin>(url);
  }

  post(assunto: Origin): Observable<Origin> {
    return this.http.post<Origin>(this.baseUrl, assunto);
  }

  put(id: number, assunto: Origin): Observable<Origin> {
    var url = this.baseUrl + id;
    return this.http.put<Origin>(url, assunto);
  }

  delete(id: number): Observable<any> {
    var url: string = this.baseUrl + id;
    return this.http.delete(url);
  }
}
