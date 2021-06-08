import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable,of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Cita } from '../models/cita';

@Injectable({
  providedIn: 'root'
})
export class CitaService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<Cita[]> {
    return this.http.get<Cita[]>( this.baseUrl + 'api/Cita').pipe(
      tap(),
      catchError(error => {
        console.log('se ha presentado un error al registrar los datos')
        return of(error as Cita[])
      })
    );
  }
  post(cita: Cita): Observable<Cita> {
    return this.http.post<Cita>(this.baseUrl + 'api/Cita',cita).pipe(
      tap(_ => console.log("Los datos se guardaron Satisfactoriamente")),
      catchError(error=>{
        console.log('se ha presentado un error al registrar los datos')
        return of(cita)
      })
    )
  }
}
