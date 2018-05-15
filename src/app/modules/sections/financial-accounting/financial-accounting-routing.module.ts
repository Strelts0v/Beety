import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FinancialAccountingComponent } from './financial-accounting.component';

const routes: Routes = [
  {
    path: '',
    component: FinancialAccountingComponent,
    data: {title: 'Финансовый учет'}
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FinancialAccountingRoutingModule {
}
