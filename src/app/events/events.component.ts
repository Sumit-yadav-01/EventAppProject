import { Component, OnInit } from '@angular/core';
import { EventAppService } from '../event-app.service';
import { AuthService } from '../authService';

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
  //create a variable to store if we are showing just favorite events
  showFavorite = false;

  //generate a constructor & add event-app.service to it
  constructor(
    private eventService: EventAppService,
    private authService: AuthService
  ) {}

  //call the getFavoriteEvents method in the ngOnInit method
  ngOnInit(): void {
    this.getFavoriteEvents();
    this.getEvents();
  }

  //create a method to fetch the events from EventAppService getEvents method
  getEvents() {
    this.eventService.getEvents().subscribe((response: any) => {
      //filter the events to show only favorite events if showFavorite is true otherwise show all events
      this.events = this.showFavorite
        ? response.events.filter((event: any) =>
            this.favoriteEvents?.some((favorite: any) => favorite == event.id)
          )
        : response.events;
    });
  }

  //create a method to favourite an event
  addFavourite(eventId: any) {
    console.log(this.authService.loggedInUser);
    this.eventService
      .addFavouriteEvent(eventId, localStorage.getItem('userId'))
      .subscribe(() => {
        this.getFavoriteEvents();
      });
  }

  //create a method to get favorite events by user
  getFavoriteEvents() {
    this.eventService
      .getFavouriteEvents(localStorage.getItem('userId'))
      .subscribe((response: any) => {
        this.favoriteEvents = response.map((event: any) => event.event_id);
        if (this.showFavorite) {
          this.events = this.events?.filter((event: any) =>
            this.favoriteEvents?.some((favorite: any) => favorite == event.id)
          );
        }
      });
  }

  //create a method to check if the event is favorite or not
  isFavorite(eventId: any) {
    return this.favoriteEvents?.some((event: any) => event == eventId);
  }

  //create a method to remove an event from favorite
  removeFavourite(eventId: any) {
    this.eventService
      .removeFavouriteEvent(eventId, localStorage.getItem('userId'))
      .subscribe(() => {
        this.getFavoriteEvents();
      });
  }
}
