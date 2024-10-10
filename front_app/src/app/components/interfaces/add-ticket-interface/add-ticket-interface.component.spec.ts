import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTicketInterfaceComponent } from './add-ticket-interface.component';

describe('AddTicketInterfaceComponent', () => {
  let component: AddTicketInterfaceComponent;
  let fixture: ComponentFixture<AddTicketInterfaceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddTicketInterfaceComponent]
    });
    fixture = TestBed.createComponent(AddTicketInterfaceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
