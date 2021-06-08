import { Cliente } from './../models/cliente';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  
  baseUrl: string;
  
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>( this.baseUrl + 'api/Cliente').pipe(
      tap(),
      catchError(error => {
        console.log('se ha presentado un error al registrar los datos')
        return of(error as Cliente[])
      })
    );
  }
  post(cliente: Cliente): Observable<Cliente> {
    return this.http.post<Cliente>(this.baseUrl + 'api/Cliente',cliente).pipe(
      tap(_ => console.log("Los datos se guardaron Satisfactoriamente")),
      catchError(error=>{
        console.log('se ha presentado un error al registrar los datos')
        return of(cliente)
      })
    )
  }
}


