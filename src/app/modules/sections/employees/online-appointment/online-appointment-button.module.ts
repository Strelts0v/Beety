import { NgModule} from '@angular/core';
import { OnlineAppointmentButtonRoutingModule } from './online-appointment-button-routing.module';
import {OnlineAppointmentButtonComponent, OnlineAppointmentComponent} from './online-appointment-button.component';
import {CommonModule} from "@angular/common";
import {MatButtonModule, MatIconModule, MatInputModule, MatTableModule} from "@angular/material";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { MaterialModule } from "../../../shared/material.module";
import { DemoModule } from "./calendar/calendar-appointment.module";
import { DemoComponent } from "./calendar/calendar-appointment.component";
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { CalendarModule } from 'angular-calendar';
import { DemoUtilsModule } from './calendar/demo-utils/demo-utils.module';

@NgModule({
  imports: [
    OnlineAppointmentButtonRoutingModule,
    CommonModule,
    MatTableModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    NgbModalModule.forRoot(),
    CalendarModule.forRoot(),
    DemoUtilsModule,
    DemoModule
  ],

  declarations: [
    OnlineAppointmentButtonComponent,
    OnlineAppointmentComponent,
  ],
  exports: [
    OnlineAppointmentButtonComponent,
  ],
  entryComponents: [OnlineAppointmentButtonComponent, OnlineAppointmentComponent, DemoComponent],
  bootstrap: [OnlineAppointmentButtonComponent],
})

export class OnlineAppointmentButtonModule {
}

