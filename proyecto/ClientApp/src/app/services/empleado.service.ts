import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, of  } from 'rxjs';
import { Empleado } from '../models/empleado';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EmpleadoService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<Empleado[]> {
    return this.http.get<Empleado[]>( this.baseUrl + 'api/Empleado').pipe(
      tap(),
      catchError(error => {
        console.log('se ha presentado un error al registrar los datos')
        return of(error as Empleado[])
      })
    );
  }
  post(empleado: Empleado): Observable<Empleado> {
    return this.http.post<Empleado>(this.baseUrl + 'api/Empleado',empleado).pipe(
      tap(_ => console.log("Los datos se guardaron Satisfactoriamente")),
      catchError(error=>{
        console.log('se ha presentado un error al registrar los datos')
        return of(empleado)
      })
    )
  }
}
