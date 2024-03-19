import { Component, OnInit } from '@angular/core';
import {
  Form,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { EventAppService } from 'src/app/event-app.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss'],
})
export class RegistrationComponent implements OnInit {
  // 1. Create a form group
  registrationForm: FormGroup = {} as FormGroup;

  //create contructor and add formbuilder
  constructor(
    private fb: FormBuilder,
    private readonly eventService: EventAppService
  ) {}

  //create a setup form method to add form controls  user id , first name, last name , email and password to registrationform  with validations
  setupForm() {
    this.registrationForm = this.fb.group({
      userId: ['', [Validators.required, Validators.minLength(5)]],
      firstName: ['', [Validators.required, Validators.minLength(3)]],
      lastName: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  //add setupform to ngOnInit
  ngOnInit() {
    this.setupForm();
  }

  // create getter for form validations
  get nameControl() {
    return this.registrationForm.get('name');
  }

  get emailControl() {
    return this.registrationForm.get('email');
  }

  get passwordControl() {
    return this.registrationForm.get('password');
  }

  // 6. Add a submit button
  onSubmit() {
    if (this.registrationForm.valid) {
      //call adduser method from eventappservice
      const payLoad={
        user_id: this.registrationForm.value.userId,
        first_name: this.registrationForm.value.firstName,
        last_name: this.registrationForm.value.lastName,
        email: this.registrationForm.value.email,
        password: this.registrationForm.value.password,
      }
      this.eventService
        .addUser(payLoad)
        .subscribe((response) => {
          //navigate to the events page
          window.location.href = '/login';
        });
    }
  }

  // 8. Add a reset button
  resetForm() {
    this.registrationForm.reset();
    // this.successMessage = '';
  }
}
