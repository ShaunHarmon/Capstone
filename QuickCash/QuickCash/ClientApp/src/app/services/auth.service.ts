import { Injectable, Inject } from '@angular/core';


@Injectable()
export class AuthService {

  public loggedIn: boolean = false;
  public user: User;

  
  constructor() { }

  isLoggedIn() {
    
    return this.loggedIn;
  }
}
