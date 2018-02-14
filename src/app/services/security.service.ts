import { Injectable } from '@angular/core';
import { AuthConstants } from '@app/constant';

@Injectable()
export class SecurityService {

  isLoggedIn() {
    return !!localStorage.getItem(AuthConstants.AUTH_TOKEN_NAME);
  }
}
