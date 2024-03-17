import { Component, OnInit } from '@angular/core';
import { EventAppService } from '../event-app.service';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {
  //create a variable to store the events
  events: any;
  //create a variable to store favorite events
  favoriteEvents: any;
  //generate a constructor & add event-app.service to it
  constructor(private eventService: EventAppService) {}

  //call the getEvents method in the ngOnInit method
  ngOnInit(): void {
    this.getEvents();
  }
  //create a method to fetch the events from EventAppService getEvents method
  getEvents() {
    this.eventService.getEvents().subscribe((response: any) => {
      this.events = response.events;
      console.log(this.events);
    });
  }
}
