import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { PageComponent } from './page.component';

import { LoginGuard } from '../../../guards/login.guard';

const loginRoutes: Routes = [
  {path: '', component: PageComponent, canActivate: [ LoginGuard ]}
];

@NgModule({
  imports: [
    RouterModule.forChild(loginRoutes)
  ],
  exports: [ RouterModule ]
})
export class PageRoutingModule {

}
