import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class EventAppService {
  //create a variable to store the url of the api
  private url = 'https://localhost:44389/api/';

  //create a contructor and inject httpclient to it
  constructor(public readonly http: HttpClient) {}

  //create a method getEvents which will fetch the data from the api
  getEvents() {
    return this.http.get(this.url + 'event');
  }

  //create a method getEvent by id which will fetch the data from the api
  getEventById(eventId: number) {
    return this.http.get(this.url + 'event/' + eventId);
  }
}
