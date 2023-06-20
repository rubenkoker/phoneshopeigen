import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhoneDetailsComponent } from './phone-details.component';

describe('PhoneDetailsComponent', () => {
  let component: PhoneDetailsComponent;
  let fixture: ComponentFixture<PhoneDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PhoneDetailsComponent]
    });
    fixture = TestBed.createComponent(PhoneDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
