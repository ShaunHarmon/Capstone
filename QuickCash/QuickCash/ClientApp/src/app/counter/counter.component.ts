import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {

  public user: User;

  ngOnInit(): void {

    if (!this.authService.isLoggedIn()) {
      this.router.navigate(['/login']);
    }
  }

  constructor(private router: Router, private authService: AuthService) {

    this.user = authService.user;
  }
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
