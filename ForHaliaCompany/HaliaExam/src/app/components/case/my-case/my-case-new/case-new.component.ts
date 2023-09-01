import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserInfo } from 'src/app/models/user-model.model';
import { AuthService } from 'src/app/services/auth.service';
import { MycasesService } from 'src/app/services/cases.service';

@Component({
  selector: 'app-my-case',
  templateUrl: './case-new.component.html',
  styleUrls: ['./case-new.component.css']
})
 
export class MyCaseComponent implements OnInit {
  
  constructor(
    private caseService: MycasesService,
    private authService: AuthService,
    private router: Router) {}

  userInfos: UserInfo[] = [];

  ngOnInit(): void{
    this.authService.getUserInfos().subscribe({
      next: (userInfos) => {
        this.userInfos = userInfos;
      },
      error: (response) => {
        console.log(response);
      }
    })
  }

  myCaseForm = new FormGroup({
    name: new FormControl('',[
      Validators.required]),
    startDate: new FormControl('',[
      Validators.required]),
    finishDate: new FormControl('',[
      Validators.required]),
    description: new FormControl('',[
      Validators.required]),
  });

  caseSaved(){
    this.caseService.saveCase([
      this.myCaseForm.value.name || '',
      this.myCaseForm.value.description || '',
      this.myCaseForm.value.startDate || '',
      this.myCaseForm.value.finishDate || ''
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

  get Name(): FormControl{
    return this.myCaseForm.get("name") as FormControl;
  }
  get StartDate(): FormControl{
    return this.myCaseForm.get("startDate") as FormControl;
  }
  get FinishDate(): FormControl{
    return this.myCaseForm.get("finishDate") as FormControl;
  }
  get Description(): FormControl{
    return this.myCaseForm.get("description") as FormControl;
  }
}