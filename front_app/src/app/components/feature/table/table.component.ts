import { Component, OnInit } from '@angular/core';
import { TicketsService } from '../../../services/tickets.service';
import { Ticket } from 'src/app/interfaces/ticket.interface';
import { TableColumn } from 'src/app/interfaces/table.interface';
import { Router } from '@angular/router';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss'],
})
export class TableComponent implements OnInit {
  table_columns: TableColumn[] = [];
  table_content: Ticket[] = [];

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
        console.log('Delete ticket:', ticketId);
        break;
      default:
        console.log('Unknown action:', action);
    }
  }
  go_to_add_ticket() {
    console.log('go_to_add_ticket');
    this.router.navigate(['ticket', 'create']);
  }
}
