import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './users/login/login.component';
import { RegistrationComponent } from './users/registration/registration.component';
import { ReactiveFormsModule } from '@angular/forms';
import { EventAppService } from './event-app.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { HeaderComponent } from './header/header.component';
import { EventsComponent } from './events/events.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MatCardModule } from '@angular/material/card';
import { AuthService } from './authService';
import { AuthGuard } from './auth.guard';
//import the MatSlideToggleModule
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatProgressBarModule } from '@angular/material/progress-bar';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    HeaderComponent,
    EventsComponent,
  ],
  //Add the ReactiveFormsModule to the imports array
  //Add the matformfieldmodule to the imports array
  //Add MatCardModule to the imports array
  //Add MatSlideToggleModule to the imports array
  //Add the MatProgressBarModule to the imports array
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    BrowserAnimationsModule,
    MatButtonModule,
    HttpClientModule,
    MatCardModule,
    MatSlideToggleModule,
    MatProgressBarModule,
  ],
  providers: [EventAppService, AuthService, AuthGuard, HttpClient],
  bootstrap: [AppComponent],
})
export class AppModule {}
