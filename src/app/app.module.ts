import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GuardsModule } from './guards/guards.module';
import { ServicesModule } from './services/services.module';
import { InterceptorsModule } from './services/interceptor/interceptors.module';
import { MaterialModule } from './modules/shared/material.module';
import { MatDialogModule } from '@angular/material';
import { TableMaterialButtonModule} from "./modules/sections/table-material/table-material-button.module";
import { OnlineAppointmentButtonModule} from "./modules/sections/employees/online-appointment/online-appointment-button.module";
import { DemoModule } from './modules/sections/employees/online-appointment/calendar/calendar-appointment.module';
import { DemoUtilsModule } from './modules/sections/employees/online-appointment/calendar/demo-utils/demo-utils.module';
import { CalendarModule } from 'angular-calendar';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { ScheduleButtonModule } from './modules/sections/employees/online-appointment/calendar/schedule/schedule-button.module';

import 'hammerjs';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/empty';
import 'rxjs/add/observable/forkJoin';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    GuardsModule,
    ServicesModule,
    AppRoutingModule,
    InterceptorsModule,
    BrowserAnimationsModule,
    MaterialModule,
    MatDialogModule,
    TableMaterialButtonModule,
    OnlineAppointmentButtonModule,
    DemoModule,
    DemoUtilsModule,
    NgbModalModule.forRoot(),
    CalendarModule.forRoot(),
    ScheduleButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule {
}
