import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent {
  constructor(private _router: Router) {}

  onLogout(): void {
    localStorage.clear();
    this._router.navigateByUrl('login');
  }

  get isLoggedIn(): boolean {
    return localStorage.getItem('token') ? true : false;
  }
}
