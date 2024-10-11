import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Ticket, TicketCreate } from '../interfaces/ticket.interface';
import { TableColumn } from '../interfaces/table.interface';

@Injectable({
  providedIn: 'root',
})
export class TicketsService {
  table_columns: TableColumn[] = [];
  table_content: Ticket[] = [];

  constructor(private http: HttpClient) {}

  get_table_columns(): TableColumn[] {
    return [
      {
        ColumnName: 'Ticket id',
        DataName: 'ticket_id',
      },
      {
        ColumnName: 'Description',
        DataName: 'description',
      },
      {
        ColumnName: 'Status',
        DataName: 'status',
      },
      {
        ColumnName: 'Date',
        DataName: 'date',
      },
      {
        ColumnName: 'Actions',
        DataName: 'actions',
      },
    ];
  }

  get_table_content(): Ticket[] {
    return [
      {
        ticket_id: 1,
        description: 'Activate account',
        status: 'Open',
        date: new Date('08-05-2022'),
        actions: ['update', 'delete'],
      },
      {
        ticket_id: 2,
        description: 'Change payment method',
        status: 'Closed',
        date: new Date('04-05-2022'),
        actions: ['update', 'delete'],
      },
      {
        ticket_id: 3,
        description: 'Request password reset',
        status: 'Open',
        date: new Date('10-10-2023'),
        actions: ['update', 'delete'],
      },
      {
        ticket_id: 4,
        description: 'Update billing address',
        status: 'Closed',
        date: new Date('05-09-2023'),
        actions: ['update', 'delete'],
      },
      {
        ticket_id: 5,
        description: 'Issue with order tracking',
        status: 'Closed',
        date: new Date('02-03-2023'),
        actions: ['update', 'delete'],
      },
      {
        ticket_id: 6,
        description: 'Report a bug on the website',
        status: 'Open',
        date: new Date('07-07-2023'),
        actions: ['update', 'delete'],
      },
    ];
  }

  get_ticket(ticket_id: number): Ticket {
    return {
      ticket_id: 1,
      description: 'Activate account',
      status: 'Open',
      date: new Date('08-05-2022'),
      actions: ['update', 'delete'],
    };
  }

  update_ticket(ticket: Ticket): boolean {
    return true;
  }

  create_ticket(ticket: TicketCreate): Ticket {
    return {
      ticket_id: 1,
      description: ticket.description,
      status: ticket.status,
      date: ticket.date,
      actions: ['update', 'delete'],
    };
  }

  delete_ticket(ticket_id: number) {
    console.log(`The ticket number ${ticket_id} id deleted successfully`);
  }
}
