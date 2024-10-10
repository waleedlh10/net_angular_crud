import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TicketsService } from 'src/app/services/tickets.service';

@Component({
  selector: 'app-add-ticket-feature',
  templateUrl: './add-ticket-feature.component.html',
  styleUrls: ['./add-ticket-feature.component.scss'],
})
export class AddTicketFeatureComponent implements OnInit {
  ticketForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private ticketsService: TicketsService,
    private router: Router
  ) {
    this.ticketForm = this.fb.group({
      description: ['', Validators.required],
      status: ['Open', Validators.required],
      date: [new Date().toISOString().substring(0, 10), Validators.required],
    });
  }

  ngOnInit(): void {}

  onSubmit(): void {
    if (this.ticketForm.valid) {
      const newTicket = this.ticketForm.value;
      console.log('New Ticket:', newTicket);

      this.ticketsService.create_ticket(newTicket);
      this.router.navigate(['tickets']);
    }
  }
}
