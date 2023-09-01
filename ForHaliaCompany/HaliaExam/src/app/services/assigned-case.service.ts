import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TempAssignedCase } from '../models/temp-assigned-case-model.model';
import { Observable } from 'rxjs';
import { AssignedAnswer } from '../models/assigned-answer-model.model';

@Injectable({
  providedIn: 'root'
})
export class AssignedCaseService {

  constructor(private http: HttpClient) { }

  baseServerUrl = 'https://localhost:44337/api/AssignedCase/'

  saveAssignedCase(assignedCaseInfo: Array<String>){
    const id=sessionStorage.getItem('id');
    console.log(this.baseServerUrl + "CreateAssignedCase?sessionUserId=" + id);
    return this.http.post(this.baseServerUrl + "CreateAssignedCase?sessionUserId=" + id, 
    {
       caseid: assignedCaseInfo[0],
       assigneduserid: assignedCaseInfo[1],
       description: assignedCaseInfo[2]
    },
    {
      responseType: 'text',
    });
  }

  getUserAssignedCases(): Observable<TempAssignedCase[]>{
    const id = sessionStorage.getItem('id');
    return this.http.get<TempAssignedCase[]>(this.baseServerUrl 
      + 'UserAssignedCasesList?sessionUserId=' + id);
  }

  getAssignedCase(id: string): Observable<AssignedAnswer>{
    return this.http.get<AssignedAnswer>(this.baseServerUrl + 
      "AssignedCaseAnswer?id=" + id);
  }
}