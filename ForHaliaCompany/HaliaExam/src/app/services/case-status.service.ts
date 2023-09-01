import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TempCaseStatus } from '../models/temp-case-status-model.model';

@Injectable({
  providedIn: 'root'
})
export class CaseStatusService {

  constructor(private http: HttpClient) { }

  baseServerUrl = 'https://localhost:44337/api/CaseStatus/'

  getCasesStatus(id: string): Observable<TempCaseStatus[]>{
    return this.http.get<TempCaseStatus[]>(this.baseServerUrl 
      + 'GetByCaseId?caseId=' + id);
  }

  saveCaseStatus(caseStatusInfo: Array<String>){
    const id=sessionStorage.getItem('id');
    return this.http.post(this.baseServerUrl + "CreateCaseStatus?sessionUserId=" + id, 
    {
       Id: caseStatusInfo[0],
       CaseId: caseStatusInfo[1],
       Status: caseStatusInfo[2],
       StatusDescription: caseStatusInfo[3]
    },
    {
      responseType: 'text',
    });
  }
}