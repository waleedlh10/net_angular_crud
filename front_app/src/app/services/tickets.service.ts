import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Ticket, TicketCreate } from '../interfaces/ticket.interface';
import { TableColumn } from '../interfaces/table.interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TicketsService {
  private apiUrl = 'http://localhost:5210/api';
  table_columns: TableColumn[] = [];
  table_content: Ticket[] = [];

  constructor(private http: HttpClient) {}

  get_table_columns(): TableColumn[] {
    let table_columns = [
      {
        ColumnName: 'Ticket id',
        DataName: 'ticketId',
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
    return table_columns;
  }

  get_table_content(
    page: number = 1,
    items_per_page: number = 10,
    ticketId?: number,
    description?: string,
    status?: string,
    date?: Date,
    order_by: string = 'ticketId',
    order_dir: string = 'asc'
  ): Observable<any> {
    // Validate items_per_page
    if (items_per_page < 1 || items_per_page > 100) {
      throw new Error('items_per_page must be between 1 and 100 .');
    }

    let params = new HttpParams()
      .set('page', page.toString())
      .set('items_per_page', items_per_page.toString())
      .set('order_by', order_by)
      .set('order_dir', order_dir);

    // Add optional filters to params
    if (ticketId !== undefined) {
      params = params.set('ticketId', ticketId.toString());
    }
    if (description) {
      params = params.set('description', description);
    }
    if (status) {
      params = params.set('status', status);
    }
    if (date) {
      params = params.set('date', new Date(date).toISOString());
      console.log('data : ', new Date(date).toISOString());
    }

    return this.http.get<any>(`${this.apiUrl}/ticket`, { params });
  }

  get_ticket(ticketId: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/ticket/${ticketId}`);
  }

  update_ticket(id: number, ticket: Ticket): Observable<void> {
    const url = `${this.apiUrl}/ticket/${id}`; // Construct the URL with the ticket ID
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
    };

    return this.http.put<void>(url, ticket, httpOptions);
  }

  create_ticket(ticket: Ticket): Observable<Ticket> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });

    return this.http.post<Ticket>(`${this.apiUrl}/ticket`, ticket, { headers });
  }

  delete_ticket(ticketId: string) {
    console.log(`The ticket number ${ticketId} id deleted successfully`);
    return this.http.delete<void>(`${this.apiUrl}/ticket/${ticketId}`);
  }
}
