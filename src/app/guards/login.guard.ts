import { Injectable } from '@angular/core';
import { CanActivate, CanLoad, Router } from '@angular/router';

import { SecurityService } from '@app/services';

@Injectable()
export class LoginGuard implements CanActivate, CanLoad {

  constructor(private securityService: SecurityService, private router: Router) {
  }

  canLoad(): boolean {
    return this.checkLogin();
  }

  canActivate(): boolean {
    return this.checkLogin();
  }

  checkLogin(): boolean {
    if (!this.securityService.isLoggedIn()) {
      return true;
    }

    this.router.navigate(['/']);
    return false;
  }
}
