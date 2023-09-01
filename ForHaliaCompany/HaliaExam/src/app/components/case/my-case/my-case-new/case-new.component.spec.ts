import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyCaseComponent } from './case-new.component';

describe('MyCaseComponent', () => {
  let component: MyCaseComponent;
  let fixture: ComponentFixture<MyCaseComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MyCaseComponent]
    });
    fixture = TestBed.createComponent(MyCaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
