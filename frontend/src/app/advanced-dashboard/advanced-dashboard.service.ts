import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';
//HttpClient service makes use of observables for all transactions
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { RequestModel } from '../models/Request';

@Injectable({
  providedIn: 'root'
})

export class AdvancedDashboardService {
  constructor(private http: HttpClient) {

  }
  //for mocking purposes
  //introductionUrl = 'assets/introduction.json'
  server : string = "https://localhost:5001/";

  getRequests(){
    const options = {
      responseType: 'json' as const,
      observe : 'body' as const,
    };

    var requestsUrl = this.server+'api/airport/requests'

    console.log(this.http.get<Array<RequestModel>>(requestsUrl, options))

    return this.http.get<Array<RequestModel>>(requestsUrl, options)
    .pipe(
      catchError(this.handleError)
    );
  }
  
  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    // Return an observable with a user-facing error message.
    return throwError(
      'Something bad happened; please try again later.');
  }


}
