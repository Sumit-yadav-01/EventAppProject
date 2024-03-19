import { ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { AuthService } from '../authService';
import { EventAppService } from '../event-app.service';
import { EventsComponent } from './events.component';

describe('EventsComponent', () => {
  let component: EventsComponent;
  let fixture: ComponentFixture<EventsComponent>;
  let mockEventAppService: any;
  let mockAuthService: any;

  beforeEach(async () => {
    mockEventAppService = jasmine.createSpyObj([
      'getEvents',
      'addFavouriteEvent',
      'getFavouriteEvents',
      'removeFavouriteEvent',
    ]);
    mockAuthService = jasmine.createSpyObj(['loggedInUser']);

    await TestBed.configureTestingModule({
      declarations: [EventsComponent],
      providers: [
        { provide: EventAppService, useValue: mockEventAppService },
        { provide: AuthService, useValue: mockAuthService },
      ],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call getEvents and getFavoriteEvents on ngOnInit', () => {
    spyOn(component, 'getEvents');
    spyOn(component, 'getFavoriteEvents');
    component.ngOnInit();
    expect(component.getEvents).toHaveBeenCalled();
    expect(component.getFavoriteEvents).toHaveBeenCalled();
  });

  it('should call addFavouriteEvent on addFavourite', () => {
    mockEventAppService.addFavouriteEvent.and.returnValue(of({}));
    component.addFavourite('eventId');
    expect(mockEventAppService.addFavouriteEvent).toHaveBeenCalled();
  });

  it('should call getFavouriteEvents on getFavoriteEvents', () => {
    mockEventAppService.getFavouriteEvents.and.returnValue(
      of([{ event_id: 'eventId' }])
    );
    component.getFavoriteEvents();
    expect(mockEventAppService.getFavouriteEvents).toHaveBeenCalled();
  });

  it('should return true if event is favorite', () => {
    component.favoriteEvents = ['eventId'];
    expect(component.isFavorite('eventId')).toBeTrue();
  });

  it('should call removeFavouriteEvent on removeFavourite', () => {
    mockEventAppService.removeFavouriteEvent.and.returnValue(of({}));
    component.removeFavourite('eventId');
    expect(mockEventAppService.removeFavouriteEvent).toHaveBeenCalled();
  });
});
