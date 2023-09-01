import { Component, OnInit } from '@angular/core';
import { TempAssignedCase } from 'src/app/models/temp-assigned-case-model.model';
import { AssignedCaseService } from 'src/app/services/assigned-case.service';

@Component({
  selector: 'app-user-assigned-case-list',
  templateUrl: './user-assigned-case-list.component.html',
  styleUrls: ['./user-assigned-case-list.component.css']
})
export class UserAssignedCaseListComponent implements OnInit {
  assignedCases: TempAssignedCase[] = [];

  constructor(private assignedCaseService: AssignedCaseService){}

  ngOnInit(): void {
    this.assignedCaseService.getUserAssignedCases().subscribe({
      next: (assignedCases) => {
        this.assignedCases = assignedCases;
        console.log(assignedCases);
      },
      error: (response) => {
        console.log(response);
      }
    })
  }
}