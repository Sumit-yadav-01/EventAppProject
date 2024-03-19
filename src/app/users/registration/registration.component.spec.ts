import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RegistrationComponent } from './registration.component';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { EventAppService } from 'src/app/event-app.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('RegistrationComponent', () => {
  let component: RegistrationComponent;
  let fixture: ComponentFixture<RegistrationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RegistrationComponent],
      providers: [
        { provide: FormBuilder, useValue: new FormBuilder() },
        { provide: EventAppService },
      ],
      imports: [ReactiveFormsModule, HttpClientTestingModule],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  //write test case to initialize form on ngOnInit
  it('should initialize form on ngOnInit', () => {
    component.ngOnInit();
    expect(component.registrationForm).toBeDefined();
  });

  //write test case to call register method on submit
  it('should call addUser method on submit', () => {
    const eventAppService = TestBed.inject(EventAppService);
    spyOn(eventAppService, 'addUser').and.callThrough();
    component.registrationForm.setValue({
      userId: 'testUser',
      firstName: 'firstName',
      lastName: 'lastName',
      email: 'email@test.com',
      password: 'password',
    });
    component.onSubmit();
    expect(eventAppService.addUser).toHaveBeenCalled();
  });
});
