import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Curso } from './curso';

var httpOptions = { headers: new HttpHeaders({ "Content-Type": "application/json" }) };

@Injectable({
  providedIn: 'root'
})
export class CursoService {

  url = 'https://localhost:44395/api/cursoes';

  constructor(private http: HttpClient) { }

  getAllCursos(): Observable<Curso[]> {
    return this.http.get<Curso[]>(this.url);
  }
  getCursoById(cursoid: string): Observable<Curso> {
    const apiurl = `${this.url}/${cursoid}`;
    return this.http.get<Curso>(apiurl);
  }
  createCurso(curso: Curso): Observable<Curso> {
    return this.http.post<Curso>(this.url, curso, httpOptions);
  }
  updateCurso(cursoid: string, curso: Curso): Observable<Curso> {
    const apiurl = `${this.url}/${cursoid}`;
    return this.http.put<Curso>(apiurl, curso, httpOptions);
  }
  deleteCursoById(cursoid: string): Observable<number> {
    const apiurl = `${this.url}/${cursoid}`;
    return this.http.delete<number>(apiurl, httpOptions);
  }
}
