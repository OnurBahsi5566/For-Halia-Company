import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CaseList } from 'src/app/models/casel-list-model.model';
import { SearchText } from 'src/app/models/search-text-model.model';
import { MycasesService } from 'src/app/services/cases.service';

@Component({
  selector: 'app-my-case-list',
  templateUrl: './case-list.component.html',
  styleUrls: ['./case-list.component.css']
})
export class MyCaseListComponent implements OnInit {

  caseslist: CaseList[] = []; 
    
  constructor(private myCasesService: MycasesService){}

  ngOnInit(): void {
    this.myCasesService.getAllCases().subscribe({
      next: (mycases) => {
        this.caseslist = mycases;
        console.log(mycases);
      },
      error: (response) => {
        console.log(response);
      }
    })
  }

  searchText = '';
}

