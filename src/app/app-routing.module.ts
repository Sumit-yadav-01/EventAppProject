import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationComponent } from './users/registration/registration.component';
import { LoginComponent } from './users/login/login.component';
import { EventsComponent } from './events/events.component';
import { AuthGuard } from './auth.guard';

// Add registration component to the routes array
//Add canActivate: [AuthGuard] to the events route
const routes: Routes = [
  { path: 'registration', component: RegistrationComponent },
  //Add login component to the routes array and make it the default route
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  //Add a route to the EventsComponent
  { path: 'events', component: EventsComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
