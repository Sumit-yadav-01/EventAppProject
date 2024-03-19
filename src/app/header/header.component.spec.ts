import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';
import { HeaderComponent } from './header.component';

describe('HeaderComponent', () => {
  let component: HeaderComponent;
  let fixture: ComponentFixture<HeaderComponent>;
  let router: Router;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HeaderComponent ],
      providers: [
        { provide: Router, useValue: { navigateByUrl: jasmine.createSpy('navigateByUrl') } }
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderComponent);
    component = fixture.componentInstance;
    router = TestBed.inject(Router);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should clear localStorage and navigate to login on logout', () => {
    spyOn(localStorage, 'clear');
    component.onLogout();
    expect(localStorage.clear).toHaveBeenCalled();
    expect(router.navigateByUrl).toHaveBeenCalledWith('login');
  });

  it('should return true if token is present in localStorage', () => {
    spyOn(localStorage, 'getItem').and.returnValue('token');
    expect(component.isLoggedIn).toBeTrue();
  });

  it('should return false if token is not present in localStorage', () => {
    spyOn(localStorage, 'getItem').and.returnValue(null);
    expect(component.isLoggedIn).toBeFalse();
  });
});