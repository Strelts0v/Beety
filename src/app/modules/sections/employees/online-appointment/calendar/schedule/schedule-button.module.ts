import { NgModule} from '@angular/core';
import {CommonModule} from "@angular/common";
import {MatButtonModule, MatIconModule, MatInputModule, MatTableModule} from "@angular/material";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { MaterialModule } from '../../../../../shared/material.module';
import { ScheduleButtonRoutingModule } from './schedule-button-routing.module';
import { ScheduleButtonComponent, ScheduleComponent } from './schedule-button.component';

@NgModule({
  imports: [
    ScheduleButtonRoutingModule,
    CommonModule,
    MatTableModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    MaterialModule
  ],

  declarations: [
    ScheduleButtonComponent,
    ScheduleComponent,
  ],
  exports: [
    ScheduleButtonComponent,
  ],
  entryComponents: [ScheduleButtonComponent, ScheduleComponent],
  bootstrap: [ScheduleButtonComponent],
})

export class ScheduleButtonModule {
}

