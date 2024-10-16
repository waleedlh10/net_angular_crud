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
  ticket!: Ticket;

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

    this.ticketsService.get_ticket(this.ticketId).subscribe(
      (data: any) => {
        console.log('data : :', data);
        this.ticket = data;
        this.initForm();
      },
      (error) => {
        console.error(error);
      }
    );
  }

  ngOnInit(): void {}

  initForm() {
    this.ticketForm = this.fb.group({
      ticketId: [
        { value: this.ticket.ticketId, disabled: true },
        Validators.required,
      ],
      description: [this.ticket.description, Validators.required],
      status: [this.ticket.status, Validators.required],
      date: [this.formatDate(new Date(this.ticket.date)), Validators.required],
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
      // updatedTicket = { ...updatedTicket, date: new Date(updatedTicket.date) };
      console.log('Updated ticket:', updatedTicket);
      this.ticketsService.update_ticket(this.ticketId, updatedTicket).subscribe(
        () => {
          console.log('Ticket updated successfully');
          this.router.navigate(['tickets']);
        },
        (error) => {
          console.error('Error updating ticket', error);
        }
      );
    }
  }
}
