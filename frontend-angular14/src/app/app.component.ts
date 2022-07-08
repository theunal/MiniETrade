import { Component } from '@angular/core';
import { AuthService } from './services/common/auth.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private authService: AuthService) { }

  isAuthenticated() {
    return this.authService.isAuthenticated()
  }

  logout() {
    this.authService.logout()
  }
}

