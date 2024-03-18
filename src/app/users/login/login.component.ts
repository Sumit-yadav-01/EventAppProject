import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EventAppService } from 'src/app/event-app.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  //create a form group
  loginForm: FormGroup = {} as FormGroup;

  //create contructor and add formbuilder
  constructor(
    private fb: FormBuilder,
    private readonly service: EventAppService
  ) {}

  //create a setup form method to add form controls  userId and password to loginform  with validations
  setupForm() {
    this.loginForm = this.fb.group({
      email: [''],
      password: [''],
    });
  }

  //add setupform to ngOnInit
  ngOnInit(): void {
    this.setupForm();
  }

  //create a submit method
  onSubmit() {
    //call the login method from the service and pass the loginform value
    this.service.login(this.loginForm.value).subscribe((data) => {
      //store the token in local storage
      localStorage.setItem('token', data.token);
      //navigate to the events page
      window.location.href = '/events';
    });
  }
}
