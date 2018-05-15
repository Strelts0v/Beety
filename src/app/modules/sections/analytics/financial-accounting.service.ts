import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, tap } from 'rxjs/operators';
import 'rxjs/add/operator/map';

@Injectable()
export class FinancialAccountingService {

    constructor(private _http: HttpClient) {
    }

    public getDates() {

    }

    public getProfit() {

    }

    getSalaries() {

    }

    public getMaterialCosts() {

    }
}
