import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GuardsModule } from '@app/guards';
import { InterceptorsModule } from '@app/services';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ServicesModule } from '@app/services';

import 'hammerjs';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/filter';
import 'rxjs/add/observable/empty';
import 'rxjs/add/observable/forkJoin';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    GuardsModule,
    ServicesModule,
    AppRoutingModule,
    InterceptorsModule,
    BrowserAnimationsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
