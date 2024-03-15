import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
//create a form group
loginForm: FormGroup={} as FormGroup;

//create contructor and add formbuilder
constructor(private fb: FormBuilder) {}

//create a setup form method to add form controls  userId and password to loginform  with validations
setupForm() {
  this.loginForm = this.fb.group({
    userId: [''],
    password: ['']
  }); 
}

//add setupform to ngOnInit
ngOnInit():void {
  this.setupForm();
}

//create a submit method
onSubmit() {
  console.log(this.loginForm.value);
}

}
