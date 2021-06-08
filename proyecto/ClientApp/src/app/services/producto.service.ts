import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable,of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Producto } from '../models/producto';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<Producto[]> {
    return this.http.get<Producto[]>( this.baseUrl + 'api/Producto').pipe(
      tap(),
      catchError(error => {
        console.log('se ha presentado un error al registrar los datos')
        return of(error as Producto[])
      })
    );
  }
  post(producto: Producto): Observable<Producto> {
    return this.http.post<Producto>(this.baseUrl + 'api/Servicio',producto).pipe(
      tap(_ => console.log("Los datos se guardaron Satisfactoriamente")),
      catchError(error=>{
        console.log('se ha presentado un error al registrar los datos')
        return of(producto)
      })
    )
  }
}
