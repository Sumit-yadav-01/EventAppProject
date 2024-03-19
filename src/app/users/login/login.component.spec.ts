import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from 'src/app/authService';
import { EventAppService } from 'src/app/event-app.service';
import { LoginComponent } from './login.component';
import { HttpClient } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LoginComponent],
      providers: [
        { provide: FormBuilder, useValue: new FormBuilder() },
        { provide: EventAppService },
        { provide: AuthService },
      ],
      imports: [ReactiveFormsModule, HttpClientTestingModule],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize form on ngOnInit', () => {
    component.ngOnInit();
    expect(component.loginForm).toBeDefined();
  });

  it('should call login on form submit and handle success', () => {
    spyOn(localStorage, 'setItem');
    component.loginForm.setValue({
      userId: 'testUser',
      password: 'password',
    });
    component.onSubmit();
  });

  it('should handle login error', () => {
    spyOn(window, 'alert');
    component.onSubmit();
  });
});
