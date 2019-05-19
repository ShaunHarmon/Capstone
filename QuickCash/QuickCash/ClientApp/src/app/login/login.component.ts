import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserService } from '../services/user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  model: any = {};
  loading = false;
  returnUrl: string;

  public users: User[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private authService: AuthService) {

    userService.getAll().subscribe(res => {

      this.users = res;

      console.log(res);
    });
  }

  login() {

    this.authService.loggedIn = false;

    for (let u of this.users) {
      if (u.rowKey === this.model.username && u.password === this.model.password) {
        this.authService.loggedIn = true;
        this.authService.user = u;

        this.router.navigate(['/']);
      }
    }
  }
}
