import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Ticket } from 'src/app/interfaces/ticket.interface';
import { TicketsService } from 'src/app/services/tickets.service';

@Component({
  selector: 'app-feature-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss'],
})
export class EditFeatureComponent {
  ticketId: number = 0;
  ticketForm!: FormGroup;
  ticket: Ticket;

  constructor(
    private fb: FormBuilder,
    private ticketsService: TicketsService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.route.paramMap.subscribe((params) => {
      this.ticketId = +params.get('id')!;
      console.log('Ticket ID:', this.ticketId);
    });

    this.ticket = this.ticketsService.get_ticket(this.ticketId);
    this.initForm();
  }

  ngOnInit(): void {}

  initForm() {
    this.ticketForm = this.fb.group({
      ticket_id: [
        { value: this.ticket.ticket_id, disabled: true },
        Validators.required,
      ],
      description: [this.ticket.description, Validators.required],
      status: [this.ticket.status, Validators.required],
      date: [this.formatDate(this.ticket.date), Validators.required],
      actions: [this.ticket.actions],
    });
  }

  formatDate(date: Date): string {
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');
    return `${year}-${month}-${day}`;
  }

  onSubmit() {
    if (this.ticketForm.valid) {
      const updatedTicket = this.ticketForm.getRawValue();
      console.log('Updated ticket:', updatedTicket);
      this.ticketsService.update_ticket(updatedTicket);
      this.router.navigate(['tickets']);
    }
  }
}
