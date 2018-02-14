import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthGuard } from './auth.guard';
import { LoginGuard } from './login.guard';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    AuthGuard,
    LoginGuard
  ]
})
export class GuardsModule {
}
