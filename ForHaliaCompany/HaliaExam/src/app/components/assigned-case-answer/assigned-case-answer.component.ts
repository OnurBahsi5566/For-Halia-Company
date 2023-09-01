import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AssignedAnswer } from 'src/app/models/assigned-answer-model.model';
import { AssignedCaseService } from 'src/app/services/assigned-case.service';
import { CaseStatusService } from 'src/app/services/case-status.service';

@Component({
  selector: 'app-assigned-case-answer',
  templateUrl: './assigned-case-answer.component.html',
  styleUrls: ['./assigned-case-answer.component.css']
})
export class AssignedCaseAnswerComponent implements OnInit {

  assignedCaseDetail: AssignedAnswer =
  {
    id: '',
    caseName: '',
    caseId:''
  }

  constructor(
    private assignedCaseService: AssignedCaseService,
    private caseStatusService: CaseStatusService,
    private router: Router,
    private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if (id) {
          this.assignedCaseService.getAssignedCase(id).subscribe({
            next: (response) => {
              this.assignedCaseDetail = response;
              console.log(response);
            }
          })
        }
      }
    })
  }

  assignedAnswerForm = new FormGroup({
    id: new FormControl(''),
    caseid: new FormControl(''),
    caseName: new FormControl(''),
    status: new FormControl('',[
      Validators.required]),
    statusDescription: new FormControl('',[
      Validators.required])
  });

  assignedAnswer(){
    this.caseStatusService.saveCaseStatus([
      this.assignedAnswerForm.value.id || '',
      this.assignedAnswerForm.value.caseid || '',
      this.assignedAnswerForm.value.status || '',
      this.assignedAnswerForm.value.statusDescription || ''
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

  get Status(): FormControl{
    return this.assignedAnswerForm.get("status") as FormControl;
  }
  get StatusDescription(): FormControl{
    return this.assignedAnswerForm.get("statusDescription") as FormControl;
  }
}
