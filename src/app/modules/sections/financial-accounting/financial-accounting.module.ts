import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MaterialModule } from './../../shared/material.module';

import { FinancialAccountingRoutingModule } from './financial-accounting-routing.module';
import { FinancialAccountingComponent } from './financial-accounting.component';
import { FinancialAccountingService } from './financial-accounting.service';

@NgModule({
    imports: [
      CommonModule,
      FinancialAccountingRoutingModule,
      MaterialModule
    ],
    declarations: [
      FinancialAccountingComponent,
    ],
    providers: [
      FinancialAccountingService,
    ]
  })

export class FinancialAccountingModule {
}
