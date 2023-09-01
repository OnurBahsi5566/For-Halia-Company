import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MyCase } from 'src/app/models/case-model.model';
import { UserInfo } from 'src/app/models/user-model.model';
import { AssignedCaseService } from 'src/app/services/assigned-case.service';
import { AuthService } from 'src/app/services/auth.service';
import { MycasesService } from 'src/app/services/cases.service';

@Component({
  selector: 'app-assigned-case-new',
  templateUrl: './assigne-case-new.component.html',
  styleUrls: ['./assigne-case-new.component.css']
})

export class AssignedCaseNewComponent implements OnInit{

  constructor(
    private assignedCaseService: AssignedCaseService,
    private authService: AuthService,
    private myCaseService: MycasesService,
    private router: Router) {}

    userInfos: UserInfo[] = [];
    caseInfos: MyCase[] = [];

    ngOnInit(): void {
      this.authService.getUserInfos().subscribe({
      next: (userInfos) => {
        this.userInfos = userInfos;
      },
      error: (response) => {
        console.log(response);
      }})
      this.myCaseService.getActiveCases().subscribe({
        next: (caseInfos) => {
          this.caseInfos = caseInfos;
        },
        error: (response) => {
          console.log(response);
        }})
    }

assginedCaseForm = new FormGroup({
    caseId: new FormControl('',[
      Validators.required]),
    userId: new FormControl('',[
      Validators.required]),
    description: new FormControl('',[
      Validators.required]),
  });

  assignedCaseSaved(){
    this.assignedCaseService.saveAssignedCase([
      this.assginedCaseForm.value.caseId || '',
      this.assginedCaseForm.value.userId || '',
      this.assginedCaseForm.value.description || ''
    ]).subscribe((res) =>{
      if (res == 'Success') {
        //this.isUserValid = false;
        alert('Success');
        this.router.navigate(['home'])
      } else {
        alert(res);
      }
    });
  }

  get CaseId(): FormControl{
    return this.assginedCaseForm.get("caseId") as FormControl;
  }
  get UserId(): FormControl{
    return this.assginedCaseForm.get("userId") as FormControl;
  }
  get Description(): FormControl{
    return this.assginedCaseForm.get("description") as FormControl;
  }
}