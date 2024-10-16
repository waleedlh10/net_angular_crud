export interface Ticket {
  ticketId: number;
  description: string;
  status: 'Open' | 'Closed';
  date: Date;
  [key: string]: any;
}

export interface TicketCreate {
  description: string;
  status: 'Open' | 'Closed';
  date: Date;
}
