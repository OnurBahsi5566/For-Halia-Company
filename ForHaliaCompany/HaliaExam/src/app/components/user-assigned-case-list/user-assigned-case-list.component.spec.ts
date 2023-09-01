import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserAssignedCaseListComponent } from './user-assigned-case-list.component';

describe('UserAssignedCaseListComponent', () => {
  let component: UserAssignedCaseListComponent;
  let fixture: ComponentFixture<UserAssignedCaseListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserAssignedCaseListComponent]
    });
    fixture = TestBed.createComponent(UserAssignedCaseListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
