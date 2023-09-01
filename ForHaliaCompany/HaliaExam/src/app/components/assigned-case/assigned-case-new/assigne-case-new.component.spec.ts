import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignedCaseNewComponent } from './assigne-case-new.component';

describe('AssignedCaseNewComponent', () => {
  let component: AssignedCaseNewComponent;
  let fixture: ComponentFixture<AssignedCaseNewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AssignedCaseNewComponent]
    });
    fixture = TestBed.createComponent(AssignedCaseNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
