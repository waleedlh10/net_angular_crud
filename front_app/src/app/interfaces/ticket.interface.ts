export interface Ticket {
  ticket_id: number;
  description: string;
  status: 'Open' | 'Closed';
  date: Date;
  actions: Array<'update' | 'delete'>;
  [key: string]: any;
}
