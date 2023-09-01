import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignedCaseAnswerComponent } from './assigned-case-answer.component';

describe('AssignedCaseAnswerComponent', () => {
  let component: AssignedCaseAnswerComponent;
  let fixture: ComponentFixture<AssignedCaseAnswerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AssignedCaseAnswerComponent]
    });
    fixture = TestBed.createComponent(AssignedCaseAnswerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
