import { Component, OnInit, ViewChild } from '@angular/core';
import { TicketsService } from '../../../services/tickets.service';
import { Ticket } from 'src/app/interfaces/ticket.interface';
import { TableColumn } from 'src/app/interfaces/table.interface';
import { Router } from '@angular/router';
import { ModalComponent } from '../modal/modal.component';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss'],
})
export class TableComponent implements OnInit {
  table_columns: TableColumn[] = [];
  table_content: Ticket[] = [];
  confirmation_modal_title: string = '';
  confirmation_modal_body: string = '';
  @ViewChild('modal', { static: false }) modal!: ModalComponent;
  ticket_selected_id!: number;

  constructor(private ticketsService: TicketsService, private router: Router) {}

  ngOnInit(): void {
    this.table_columns = this.ticketsService.get_table_columns();
    this.table_content = this.ticketsService.get_table_content();
  }

  performAction(action: string, ticketId: number) {
    switch (action) {
      case 'update':
        this.router.navigate([`/ticket/${ticketId}`]);
        break;
      case 'delete':
        this.confirmation_modal_title = 'Delete Ticket Confirmation';
        this.confirmation_modal_body =
          'Are you sure you want to delete this ticket? This action cannot be undone.';
        this.openModal();
        this.ticket_selected_id = ticketId;
        break;
      default:
        console.log('Unknown action:', action);
    }
  }
  go_to_add_ticket() {
    console.log('go_to_add_ticket');
    this.router.navigate(['ticket', 'create']);
  }

  openModal(): void {
    this.modal.show();
  }

  delete_ticket(): void {
    if (this.ticket_selected_id)
      this.ticketsService.delete_ticket(this.ticket_selected_id);
  }
}
