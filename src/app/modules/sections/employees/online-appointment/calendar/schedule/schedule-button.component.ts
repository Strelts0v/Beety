import {Component, Input, Output, Injectable, EventEmitter} from '@angular/core';
import {MatDialog} from '@angular/material';
import { TableDataSource, ValidatorService } from 'angular4-material-table';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Injectable()
export class ConsumablesValidatorService implements ValidatorService {
  getRowValidator(): FormGroup {
    return new FormGroup({
      'startTime': new FormControl(null, Validators.required),
      'endTime': new FormControl(),
    });
  }
}


class Consumables {
  startTime: string;
  endTime: string;
}

@Component({
  selector: 't-schedule',
  styleUrls: ['schedule.component.scss'],
  templateUrl: 'schedule.component.html',
  providers: [
    {provide: ValidatorService, useClass: ConsumablesValidatorService }
  ],
})
export class ScheduleComponent {

  constructor(private personValidator: ValidatorService, public dialog: MatDialog) { }

  displayedColumns = ['startTime', 'endTime', 'actionsColumn'];

  @Input() personList = [
    { startTime: '8:00', endTime: '13:00' },
    { startTime: '8:00', endTime: '14:00' },
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
}


@Component({
  selector: 't-schedule-button',
  styleUrls: ['schedule-button.component.scss'],
  templateUrl: './schedule-button.component.html',
  entryComponents: [ ScheduleComponent]
})

export class ScheduleButtonComponent {
  constructor(public dialog: MatDialog) {}

  openDialog() {
    this.dialog.open(ScheduleComponent, {
      data: {
        animal: 'panda'
      },
      height:'100%',
      position: {top: '0%', left: '0%'}
    });
  }
}
