import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TempCaseStatus } from 'src/app/models/temp-case-status-model.model';
import { CaseStatusService } from 'src/app/services/case-status.service';

@Component({
  selector: 'app-case-status-list',
  templateUrl: './case-status-list.component.html',
  styleUrls: ['./case-status-list.component.css']
})
export class CaseStatusListComponent implements OnInit {

  casesStatus: TempCaseStatus[] = [];

  constructor(
    private caseStatusService: CaseStatusService,
    private route: ActivatedRoute){}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if (id) {
          this.caseStatusService.getCasesStatus(id).subscribe({
            next: (response) => {
              this.casesStatus = response;
              console.log(response);
            }
          })
        }
      }
    })
  }
}
