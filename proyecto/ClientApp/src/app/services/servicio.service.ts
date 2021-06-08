import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable,of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Servicio } from '../models/servicio';
@Injectable({
  providedIn: 'root'
})
export class ServicioService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<Servicio[]> {
    return this.http.get<Servicio[]>( this.baseUrl + 'api/Servicio').pipe(
      tap(),
      catchError(error => {
        console.log('se ha presentado un error al registrar los datos')
        return of(error as Servicio[])
      })
    );
  }
  post(servicio: Servicio): Observable<Servicio> {
    return this.http.post<Servicio>(this.baseUrl + 'api/Servicio',servicio).pipe(
      tap(_ => console.log("Los datos se guardaron Satisfactoriamente")),
      catchError(error=>{
        console.log('se ha presentado un error al registrar los datos')
        return of(servicio)
      })
    )
  }
}
