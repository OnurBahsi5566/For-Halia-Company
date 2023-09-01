import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyCaseListComponent } from './case-list.component';

describe('MyCaseListComponent', () => {
  let component: MyCaseListComponent;
  let fixture: ComponentFixture<MyCaseListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MyCaseListComponent]
    });
    fixture = TestBed.createComponent(MyCaseListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
