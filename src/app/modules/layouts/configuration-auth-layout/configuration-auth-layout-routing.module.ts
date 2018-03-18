import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ConfigurationAuthLayoutComponent } from './configuration-auth-layout.component';
import { States } from '../../../constant/states.constant';

const configurationAuthLayoutRoutes: Routes = [
  {
    path: '',
    component: ConfigurationAuthLayoutComponent,
    children: [
      {
        path: '',
        redirectTo: States.START_PAGE,
      },
      {
        path: States.START_PAGE,
        loadChildren: '../../sections/start-page/start-page.module#StartPageModule'
      },
      {
        path: 'registration',
        loadChildren: '../../sections/registration/registration.module#RegistrationModule'
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(configurationAuthLayoutRoutes)
  ],
  exports: [RouterModule]
})

export class ConfigurationAuthLayoutRoutingModule {
}
