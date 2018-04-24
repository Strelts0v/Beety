import { Component, HostListener } from '@angular/core';
import { SideNavService } from '../../../../services/side-nav.service';
import { States } from '../../../../constant/states.constant';
import { MenuItem } from './menu-item.model';
import { KeyCodes } from '../../../../constant/key-codes.constants';


@Component({
  selector: 't-organization-side-nav',
  templateUrl: './organization-side-nav.component.html'
})
export class OrganizationSideNavComponent {
  readonly menuItems = [
    new MenuItem('Сотрудники', ['/', States.ORGANIZATION, States.EMPLOYEES], 'person'),
    new MenuItem('Клиенты', ['/', States.ORGANIZATION, States.CLIENTS], 'people'),
    new MenuItem('Обзор', ['/', States.ORGANIZATION, States.OVERVIEW], 'view_module'),
    new MenuItem('Аналитика', ['/', States.ORGANIZATION, States.ANALYTICS], 'show_chart'),
    new MenuItem('Финансы', ['/', States.ORGANIZATION, States.FINANCE], 'attach_money'),
    new MenuItem('Расчет зарплат', ['/', States.ORGANIZATION, States.CALCULATION_OF_SALARIES], 'credit_card'),
    new MenuItem('Складской учет', ['/', States.ORGANIZATION, States.STORAGE], 'storage'),
  ];

  constructor(private sideNavService: SideNavService) {
  }

  isShown(): boolean {
    return this.sideNavService.isShown();
  }

  close(): void {
    this.sideNavService.close();
  }
}
