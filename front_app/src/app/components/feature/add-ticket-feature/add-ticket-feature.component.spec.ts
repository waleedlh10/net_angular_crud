import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTicketFeatureComponent } from './add-ticket-feature.component';

describe('AddTicketFeatureComponent', () => {
  let component: AddTicketFeatureComponent;
  let fixture: ComponentFixture<AddTicketFeatureComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddTicketFeatureComponent]
    });
    fixture = TestBed.createComponent(AddTicketFeatureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
