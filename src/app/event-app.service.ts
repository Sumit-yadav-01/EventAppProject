import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class EventAppService {
  //create a variable to store the url of the api
  private url = 'https://localhost:44389/api/';

  //create a contructor and inject httpclient to it
  constructor(public readonly http: HttpClient) {}

  //create a login method which will send email and password to the api and get a jwt token
  login(loginData: any): Observable<any> {
    return this.http.post(this.url + 'login', loginData);
  }

  //create a register method
  register(registerData: any): Observable<any> {
    return this.http.post(this.url + 'user', registerData);
  }

  //create a method getEvents which will fetch the data from the api
  getEvents() {
    return this.http.get(this.url + 'event');
  }

  //create a method getEvent by id which will fetch the data from the api
  getEventById(eventId: number): Observable<any> {
    return this.http.get(this.url + 'event/' + eventId);
  }
}
