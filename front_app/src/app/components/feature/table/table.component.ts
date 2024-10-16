import { Component, OnInit, ViewChild } from '@angular/core';
import { TicketsService } from '../../../services/tickets.service';
import { Ticket } from 'src/app/interfaces/ticket.interface';
import { TableColumn } from 'src/app/interfaces/table.interface';
import { Router } from '@angular/router';
import { ModalComponent } from '../modal/modal.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastComponent } from '../toast/toast.component';

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
  order_col: string = ''; // sort column name
  order_dir: 'asc' | 'desc' = 'asc'; // sort direction
  filters_form: FormGroup = this.fb.group({}); // filter form
  @ViewChild(ToastComponent) toast!: ToastComponent;
  toast_message: string = '';
  toast_timeout: number = 5;
  total_pages: number = 1;
  page: number = 1;
  item_per_page: number = 10;

  constructor(
    private ticketsService: TicketsService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.table_columns = this.get_table_columns();
    this.get_table_content();
    this.order_col = this.table_columns[0].DataName;
    this.generateForm();
  }

  get_table_columns() {
    return this.ticketsService.get_table_columns();
  }

  get_table_content() {
    const { ticketId, description, status, date } = this.filters_form.value;

    console.log('date', date);

    this.ticketsService
      .get_table_content(
        this.page,
        this.item_per_page,
        ticketId,
        description,
        status,
        date,
        this.order_col,
        this.order_dir
      )
      .subscribe({
        next: (data) => {
          this.table_content = data.tickets;
          this.page = data.page;
          this.total_pages = data.total_pages;
        },
        error: () => {},
      });
    // return ;
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
    this.router.navigate(['ticket', 'create']);
  }

  openModal(): void {
    this.modal.show();
  }

  delete_ticket(): void {
    if (this.ticket_selected_id) {
      this.ticketsService
        .delete_ticket(`${this.ticket_selected_id}`)
        .subscribe({
          next: () => {
            this.show_toast(
              `The ticket number ${this.ticket_selected_id} deleted successfully`
            );
            this.get_table_content();
          },
          error: () => {},
        });
    }
  }

  change_order(column_name: string) {
    if (column_name !== 'actions') {
      if (this.order_col != column_name) this.order_col = column_name;
      else
        this.order_dir = this.order_dir =
          this.order_dir === 'desc' ? 'asc' : 'desc';

      this.get_table_content();
    }
  }

  generateForm(): void {
    this.table_columns.forEach((field) => {
      this.filters_form.addControl(field.DataName, this.fb.control(''));
    });
  }

  show_toast(message: string, timeout: number = 5) {
    this.toast_message = message;
    this.toast_timeout = timeout;

    this.toast.show();
  }

  get_next_page() {
    if (this.page < this.total_pages) {
      this.page += 1;
      this.get_table_content();
    }
  }
  get_prevent_page() {
    if (this.page > 1) {
      this.page -= 1;
      this.get_table_content();
    }
  }
}
