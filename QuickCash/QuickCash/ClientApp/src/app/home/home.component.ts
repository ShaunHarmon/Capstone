import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { JobsService } from '../services/jobs.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  public user: User;
  public jobs: Job[];

  constructor(
      private router: Router,
      private authService: AuthService,
      private jobService: JobsService) {

      this.user = authService.user;
      console.log(this.user);
  }

  ngOnInit(): void {
    this.jobService.getAll().subscribe(res => {

      this.jobs = res;

      console.log(res);
    });
    if (!this.authService.isLoggedIn()) {
      this.router.navigate(['/login']);
    }
  }
}
