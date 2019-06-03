import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { JobsService } from '../services/jobs.service';
import { CounterComponent } from '../counter/counter.component';
import { SelectionsService } from '../services/selections.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styleUrls: ['./fetch-data.css']
})
export class FetchDataComponent {

  public user: User;
  public jobs: Job[];

  

  ngOnInit(): void {

    if (!this.authService.isLoggedIn()) {
      this.router.navigate(['/login']);
    }
  }

  constructor(
    public authService: AuthService,
    private router: Router,
    private jobService: JobsService,
    private selectionService: SelectionsService) {

    this.user = authService.user;
    this.jobs = this.selectionService.selection;

  } 
  

}



