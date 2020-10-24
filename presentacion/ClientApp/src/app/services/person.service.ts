import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Person } from '../models/person';
import { tap, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { DecimalPipe } from '@angular/common';

@Injectable({
  providedIn: 'root'
})


export class PersonService {

  baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private handleErrorService: HandleHttpErrorService)
  {
    this.baseUrl = baseUrl;
  }
  deliveredVale: number=0;
  maxAids: number = 600000000;

  getPerson(person: Person): Observable<Person>{
    
     return this.http.get<Person>(this.baseUrl + 'api/Person' +'/'+person.identification)
     .pipe(tap(_ => this.handleErrorService.log('persona verificada')),
     catchError(this.handleErrorService.handleError<Person>('Persona buscada',new Person()))
     );
  }

  post(person: Person): Observable<Person> {
    return this.http.post<Person>(this.baseUrl + 'api/Person',person)
           .pipe(tap(_ => this.handleErrorService.log('datos guardaados')),
            catchError(this.handleErrorService.handleError<Person>('Registra Persona', null))
 );
 }

 get(): Observable<Person[]> 
  {
    return this.http.get<Person[]>(this.baseUrl + 'api/Person').
      pipe(tap(_ => this.handleErrorService.log('datos consultados')),
      catchError(this.handleErrorService.handleError<Person[]>('Consultar Persona', null))
  );
}
getSumaSupport(): Observable<number>
{
  return this.http.get<number>(this.baseUrl + 'api/Support')
    .pipe(tap(_ => this.handleErrorService.log('ayudas consultadas')),
    catchError(this.handleErrorService.handleError<number>('Suma de ayudas', 0))
    );
}

}


