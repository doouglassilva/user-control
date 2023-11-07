import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { retry, catchError } from 'rxjs/operators';
import { throwError, Observable } from 'rxjs';
import { Usuario } from '../models/usuario';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  private url = environment.apiUrl + '/api/usuarios';

  constructor(private httpClient: HttpClient) {}

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  obterTodosUsuarios(): Observable<Usuario[]> {
    return this.httpClient.get<Usuario[]>(this.url).pipe(
      retry(2),
      catchError(this.handleError)
    );
  }

  obterUsuario(id: number): Observable<Usuario> {
    return this.httpClient.get<Usuario>(`${this.url}/${id}`).pipe(
      retry(2),
      catchError(this.handleError)
    );
  }

  criarUsuario(usuario: Usuario): Observable<Usuario> {
    return this.httpClient.post<Usuario>(this.url, JSON.stringify(usuario), this.httpOptions).pipe(
      retry(1),
      catchError(this.handleError)
    );
  }

  atualizarUsuario(usuario: Usuario): Observable<Usuario> {
    return this.httpClient.put<Usuario>(this.url, JSON.stringify(usuario), this.httpOptions).pipe(
      retry(1),
      catchError(this.handleError)
    );
  }

  excluirUsuario(usuario: Usuario): Observable<void> {
    return this.httpClient
      .delete<void>(`${this.url}/${usuario.id}`, this.httpOptions)
      .pipe(retry(1), catchError(this.handleError));
  }

  handleError(error: HttpErrorResponse): Observable<never> {
    if (error.error instanceof ErrorEvent) {
      return throwError(`Erro no cliente: ${error.error.message}`);
    } else {
      return throwError(`Erro no servidor: ${error.status} - ${error.error}`);
    }
  }
}
