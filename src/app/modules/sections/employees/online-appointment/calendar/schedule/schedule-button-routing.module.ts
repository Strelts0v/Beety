import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ScheduleButtonComponent } from './schedule-button.component';

const loginRoutes: Routes = [
  {
    path: '',
    component: ScheduleButtonComponent,
    data: {title: 'Beety'}
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(loginRoutes)
  ],
  exports: [RouterModule]
})

export class ScheduleButtonRoutingModule {
}
