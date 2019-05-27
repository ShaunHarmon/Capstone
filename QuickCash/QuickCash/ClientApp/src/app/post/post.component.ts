import { Component, OnInit, Inject } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { JobsService } from '../services/jobs.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})

export class PostComponent implements OnInit {

  model: any = {};
  public user: User;
  loading = false;
  returnUrl: string;

  ngOnInit(): void {
    if (!this.authService.isLoggedIn()) {
      this.router.navigate(['/login']);
    }
  }

  constructor(
    private router: Router,
    private authService: AuthService,
    private route: ActivatedRoute,
    private jobService: JobsService) { }

  post() {
    this.jobService.create(this.model)
      .subscribe(
        data => {

          this.router.navigate(['/']);

        },
        error => {
          this.loading = false;
        });
  }
}
