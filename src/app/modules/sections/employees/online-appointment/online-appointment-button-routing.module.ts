import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import {OnlineAppointmentButtonComponent} from "./online-appointment-button.component";

const loginRoutes: Routes = [
  {
    path: '',
    component: OnlineAppointmentButtonComponent,
    data: {title: 'Beety'}
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(loginRoutes)
  ],
  exports: [RouterModule]
})

export class OnlineAppointmentButtonRoutingModule {
}
