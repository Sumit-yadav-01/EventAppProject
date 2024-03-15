import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './users/login/login.component';
import { RegistrationComponent } from './users/registration/registration.component';
import { ReactiveFormsModule } from '@angular/forms';
import { EventAppService } from './event-app.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent
  ],
  //Add the ReactiveFormsModule to the imports array
  //Add the matformfieldmodule to the imports array
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
  ],
  providers: [EventAppService],
  bootstrap: [AppComponent]
})
export class AppModule { }
