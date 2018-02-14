import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfigurationMainLayoutRoutingModule } from './configuration-main-layout-routing.module';

import { ConfigurationMainLayoutComponent } from './configuration-main-layout.component';

@NgModule({
  imports: [
    CommonModule,
    ConfigurationMainLayoutRoutingModule
  ],
  declarations: [
    ConfigurationMainLayoutComponent
  ]
})
export class ConfigurationMainLayoutModule {
}
