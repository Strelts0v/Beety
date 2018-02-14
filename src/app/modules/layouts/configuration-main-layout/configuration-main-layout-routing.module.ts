import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ConfigurationMainLayoutComponent } from './configuration-main-layout.component';
import { States } from '@app/constant';

const configurationMainLayoutRoutes: Routes = [
  {
    path: '',
    component: ConfigurationMainLayoutComponent,
    children: [
      {
        path: '',
        loadChildren: '../../sections/page/page.module#PageModule',
      },
      {
        path: States.PAGE,
        loadChildren: '../../sections/page/page.module#PageModule',
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(configurationMainLayoutRoutes)
  ],
  exports: [RouterModule]
})
export class ConfigurationMainLayoutRoutingModule {

}
