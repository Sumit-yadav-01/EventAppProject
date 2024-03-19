import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventsComponent } from './events.component';

describe('EventsComponent', () => {
  let component: EventsComponent;
  let fixture: ComponentFixture<EventsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EventsComponent],
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

  // write test cases for the methods
  it('should call getFavoriteEvents method', () => {
    spyOn(component, 'getFavoriteEvents');
    component.ngOnInit();
    expect(component.getFavoriteEvents).toHaveBeenCalled();
  });

  it('should call getEvents method', () => {
    spyOn(component, 'getEvents');
    component.ngOnInit();
    expect(component.getEvents).toHaveBeenCalled();
  });

  it('should call getEvents method', () => {
    spyOn(component, 'getEvents');
    component.onToggle();
    expect(component.getEvents).toHaveBeenCalled();
  });

  it('should call getFavoriteEvents method', () => {
    spyOn(component, 'getFavoriteEvents');
    component.addFavourite('1');
    expect(component.getFavoriteEvents).toHaveBeenCalled();
  });

  it('should call getFavoriteEvents method', () => {
    spyOn(component, 'getFavoriteEvents');
    component.addFavourite('1');
    expect(component.getFavoriteEvents).toHaveBeenCalled();
  });

  it('should call getFavoriteEvents method', () => {
    spyOn(component, 'getFavoriteEvents');
    component.addFavourite('1');
    expect(component.getFavoriteEvents).toHaveBeenCalled();
  });

  it('should call getFavoriteEvents method', () => {
    spyOn(component, 'getFavoriteEvents');
    component.onToggle();
    expect(component.getFavoriteEvents).toHaveBeenCalled();
  });

  it('should call getEvents method', () => {
    spyOn(component, 'getEvents');
    component.onToggle();
    expect(component.getEvents).toHaveBeenCalled();
  });
});
