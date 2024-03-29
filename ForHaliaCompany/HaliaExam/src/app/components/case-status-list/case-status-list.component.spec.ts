import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CaseStatusListComponent } from './case-status-list.component';

describe('CaseStatusListComponent', () => {
  let component: CaseStatusListComponent;
  let fixture: ComponentFixture<CaseStatusListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CaseStatusListComponent]
    });
    fixture = TestBed.createComponent(CaseStatusListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
