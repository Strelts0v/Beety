import {Component, Input, Output, Injectable, EventEmitter} from '@angular/core';
import {MatDialog} from '@angular/material';
import { TableDataSource, ValidatorService } from 'angular4-material-table';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { DemoComponent } from './calendar/calendar-appointment.component';

@Injectable()
export class ConsumablesValidatorService implements ValidatorService {
  getRowValidator(): FormGroup {
    return new FormGroup({
      'name': new FormControl(null, Validators.required)
    });
  }
}


class Consumables {
  name: string;
}

@Component({
  selector: 't-online-appointment',
  styleUrls: ['online-appointment.component.scss'],
  templateUrl: 'online-appointment.component.html',
  providers: [
    {provide: ValidatorService, useClass: ConsumablesValidatorService }
  ],
})
export class OnlineAppointmentComponent {

  constructor(private personValidator: ValidatorService, public dialog: MatDialog) { }

  displayedColumns = ['name', 'actionsColumn'];

  @Input() personList = [
    { name: 'Pastushenko Serioga'},
    { name: 'Help Me'},
    { name: 'Mr Jon'}
  ] ;
  @Output() personListChange = new EventEmitter<Consumables[]>();

  dataSource: TableDataSource<Consumables>;


  DownloadData(){
    /*Тут вызов сервиса, чтобы получить все материалы*/
  }

  UpoadData(){
    /*Тут вызов сервиса, чтобы отправить все изменнёные или новые материалы*/
  }

  ngOnInit() {
    this.dataSource = new TableDataSource<any>(this.personList, Consumables, this.personValidator);

    this.dataSource.datasourceSubject.subscribe(personList => this.personListChange.emit(personList));
  }
  calendarShow(name) {
    this.dialog.open(DemoComponent, {
      data: {
        name: name
      },
      minWidth: '50%',
      height: '100%',
      position: { top: '0%', left: '400px' }
    });
  }
}


@Component({
  selector: 't-online-appointment-button',
  styleUrls: ['online-appointment-button.component.scss'],
  templateUrl: './online-appointment-button.component.html',
  entryComponents: [ OnlineAppointmentComponent]
})

export class OnlineAppointmentButtonComponent {
  constructor(public dialog: MatDialog) {}

  openDialog() {
    this.dialog.open(OnlineAppointmentComponent, {
      data: {
        animal: 'panda'
      },
      width: '400px',
      height:'100%',
      position: {top: '0%', left: '0%'}
    });
  }
}
