import { Injectable } from '@angular/core';
import { CanActivate, CanLoad, Router } from '@angular/router';

import { States } from '@app/constant';

import { SecurityService } from '@app/services';

@Injectable()
export class AuthGuard implements CanActivate, CanLoad {

  constructor(private securityService: SecurityService,
              private router: Router) {
  }

  canLoad(): boolean {
    return this.checkLogin();
  }

  canActivate(): boolean {
    return this.checkLogin();
  }

  checkLogin(): boolean {
    if (this.securityService.isLoggedIn()) {
      return true;
    }

    this.router.navigate([States.LOGIN]);
    return false;
  }
}
