import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';

import { FinancialAccountingService } from './financial-accounting.service';

@Component({
  selector: 't-financial-accounting',
  templateUrl: './financial-accounting.component.html'
})

export class FinancialAccountingComponent implements OnInit {

  chart = [];

  constructor(private financialService: FinancialAccountingService) { }

  ngOnInit() {
//     const temp_max = [3000, 4000, 3400, 3500, 3300, 3800, 4000, 4200];
//     const temp_min = [1000, 1200, 1100, 1400, 1500, 1500, 1450, 1500];
//     let alldates = [new Date(2018, 3, 17), new Date(2018, 3, 18), new Date(2018, 3, 19), new Date(2018, 3, 20),
//                     new Date(2018, 3, 21), new Date(2018, 3, 22), new Date(2018, 3, 23), new Date(2018, 3, 24)];

//     let weatherDates = [];
//     alldates.forEach((res) => {
//         weatherDates.push(res.toLocaleTimeString('en', { year: 'numeric', month: 'short', day: 'numeric' }));
//     });

//     this.chart = new Chart('canvas', {
//         type: 'line',
//         data: {
//             labels: weatherDates,
//             datasets: [
//                 {
//                     data: temp_max,
//                     borderColor: '#3cba9f',
//                     fill: false
//                 },
//                 {
//                     data: temp_min,
//                     borderColor: '#ffcc00',
//                     fill: false
//                 },
//             ]
//         },
//         options: {
//             legend: {
//                 display: false
//             },
//             scales: {
//                 xAxes: [{
//                     display: true
//                 }],
//                 yAxes: [{
//                     display: true
//                 }],
//             }
//         }
//     });
  }

}
