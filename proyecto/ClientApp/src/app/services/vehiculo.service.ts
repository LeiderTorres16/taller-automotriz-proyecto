import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Vehiculo } from '../models/vehiculo';

@Injectable({
  providedIn: 'root'
})
export class VehiculoService {
  baseURL: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
  }

  get(): Observable<Vehiculo[]>{
    return this.http.get<Vehiculo[]>(this.baseURL + 'api/Vehiculo').pipe(
      tap(),
      catchError(error => {
        console.log('se ha presentado un error al registrar los datos')
        return of(error as Vehiculo[])
      })
    );
  }

  post(vehiculo: Vehiculo): Observable<Vehiculo> {
    return this.http.post<Vehiculo>(this.baseURL + 'api/Vehiculo',vehiculo).pipe(
      tap(_ => console.log("Los datos se guardaron Satisfactoriamente")),
      catchError(error=>{
        console.log('se ha presentado un error al registrar los datos')
        return of(vehiculo)
      })
    )
  }
}