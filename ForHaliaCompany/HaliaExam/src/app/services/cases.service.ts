import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MyCase } from '../models/case-model.model';
import { Observable } from 'rxjs';
import { CaseList } from '../models/casel-list-model.model';

@Injectable({
  providedIn: 'root'
})
export class MycasesService {

  constructor(private http: HttpClient) { }
  
  baseServerUrl = 'https://localhost:44337/api/Case/'

  getAllCases(): Observable<CaseList[]>{
    return this.http.get<CaseList[]>(this.baseServerUrl + 'GetAllCases');
  }

  getActiveCases(): Observable<MyCase[]>{
    return this.http.get<MyCase[]>(this.baseServerUrl + 'GetActiveCases');
  }

  saveCase(caseInfo: Array<String>){
    const id=sessionStorage.getItem('id');
    return this.http.post(this.baseServerUrl + "CreateCase?sessionUserId=" + id, 
    {
       name: caseInfo[  0],
       description: caseInfo[1],
       startdate: caseInfo[2],
       finishdate: caseInfo[3]
    },
    {
      responseType: 'text',
    });
  }

  getmyCase(id: string): Observable<MyCase>{
    return this.http.get<MyCase>(this.baseServerUrl + id);
  }

  updateCase(caseInfo: Array<string>){
    return this.http.put(this.baseServerUrl + 'EditCase',
    {
      id: caseInfo[0],
      Name: caseInfo[1],
      Description: caseInfo[2],
      StartDate: caseInfo[3],
      FinishDate: caseInfo[4]
    });
  }  
}
