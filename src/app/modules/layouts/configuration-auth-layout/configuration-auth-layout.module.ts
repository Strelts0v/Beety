import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfigurationAuthLayoutRoutingModule } from './configuration-auth-layout-routing.module';

import { ConfigurationAuthLayoutComponent } from './configuration-auth-layout.component';

@NgModule({
  imports: [
    CommonModule,
    ConfigurationAuthLayoutRoutingModule,
  ],
  declarations: [
    ConfigurationAuthLayoutComponent
  ]
})
export class ConfigurationAuthLayoutModule {
}
