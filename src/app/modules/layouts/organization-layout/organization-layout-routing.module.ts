import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { States } from '../../../constant/states.constant';

import { ConfigurationMainLayoutComponent } from './organization-layout.component';
import { EmployeesModule } from '../../sections/employees/employees.module';
import { ClientsModule } from '../../sections/clients/clients.module';
import { FinancialAccountingModule } from '../../sections/financial-accounting/financial-accounting.module';

const configurationMainLayoutRoutes: Routes = [
  {
    path: '',
    component: ConfigurationMainLayoutComponent,
    children: [
      {
        path: States.EMPLOYEES,
        loadChildren: '../../sections/employees/employees.module#EmployeesModule',
      },
      {
        path: States.CLIENTS,
        loadChildren: '../../sections/clients/clients.module#ClientsModule',
      },
      {
        path: States.FINANCE,
        loadChildren: '../../sections/financial-accounting/financial-accounting.module#FinancialAccountingModule',
      },
      {
        path: States.ANALYTICS,
        loadChildren: '../../sections/analytics/financial-accounting.module#FinancialAccountingModule',
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

export class OrganizationLayoutRoutingModule {
}
