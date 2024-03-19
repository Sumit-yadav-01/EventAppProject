import { TestBed } from '@angular/core/testing';
import {
  HttpClientTestingModule,
  HttpTestingController,
} from '@angular/common/http/testing';
import { EventAppService } from './event-app.service';

describe('EventAppService', () => {
  let service: EventAppService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [EventAppService],
    });

    service = TestBed.inject(EventAppService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify(); // Ensure that there are no outstanding requests
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should call the login API', () => {
    const loginData = { email: 'test@test.com', password: 'password' };
    service.login(loginData).subscribe();

    const req = httpMock.expectOne('https://localhost:44389/api/login');
    expect(req.request.method).toBe('POST');
    expect(req.request.body).toEqual(loginData);
  });

  // Add similar test cases for register, getEvents, getEventById, addFavouriteEvent, getFavouriteEvents, removeFavouriteEvent, and addUser
  it('should call the register API', () => {
    const registerData = { email: 'test@test.com', password: 'password' };
    service.register(registerData).subscribe();

    const req = httpMock.expectOne('https://localhost:44389/api/user');
    expect(req.request.method).toBe('POST');
    expect(req.request.body).toEqual(registerData);
  });

  it('should call the getEvents API', () => {
    service.getEvents().subscribe();

    const req = httpMock.expectOne('https://localhost:44389/api/event');
    expect(req.request.method).toBe('GET');
  });

  it('should call the getEventById API', () => {
    const eventId = '1';
    service.getEventById(eventId).subscribe();

    const req = httpMock.expectOne(
      `https://localhost:44389/api/event/${eventId}`
    );
    expect(req.request.method).toBe('GET');
  });

  it('should call the addFavouriteEvent API', () => {
    const eventId = '1';
    const userId = '1';
    service.addFavouriteEvent(eventId, userId).subscribe();

    const req = httpMock.expectOne(
      `https://localhost:44389/api/event/favourite?eventId=${eventId}&userId=${userId}`
    );
    expect(req.request.method).toBe('POST');
  });

  it('should call the getFavouriteEvents API', () => {
    const userId = '1';
    service.getFavouriteEvents(userId).subscribe();

    const req = httpMock.expectOne(
      `https://localhost:44389/api/event/favourite/${userId}`
    );
    expect(req.request.method).toBe('GET');
  });

  it('should call the removeFavouriteEvent API', () => {
    const eventId = '1';
    const userId = '1';
    service.removeFavouriteEvent(eventId, userId).subscribe();

    const req = httpMock.expectOne(
      `https://localhost:44389/api/event?eventId=${eventId}&userId=${userId}`
    );
    expect(req.request.method).toBe('DELETE');
  });

  it('should call the addUser API', () => {
    const user = {
      name: 'Test User',
      email: 'test@test.com',
      password: 'password',
    };
    service.addUser(user).subscribe();

    const req = httpMock.expectOne('https://localhost:44389/api/user');
    expect(req.request.method).toBe('POST');
    expect(req.request.body).toEqual(user);
  });
});
