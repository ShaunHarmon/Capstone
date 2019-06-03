import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { JobsService } from '../services/jobs.service';
import { SelectionsService } from '../services/selections.service';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.component.css']
})
export class CounterComponent {

  public user: User;
  public jobs: Job[];



  ngOnInit(): void {
    this.jobService.getAll().subscribe(res => {

      this.jobs = res;

      console.log(res);
    });


    if (!this.authService.isLoggedIn()) {
      this.router.navigate(['/login']);
    }
  }

  

  constructor(private router: Router,
    private authService: AuthService,
    private jobService: JobsService,
    private selectionService: SelectionsService) {

    this.user = authService.user;
  }
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }

  public addJob(job) {
    //console.log(job);
    this.selectionService.selection.push(job);
  }


}
