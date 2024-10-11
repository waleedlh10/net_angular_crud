import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-toast',
  templateUrl: './toast.component.html',
  styleUrls: ['./toast.component.scss'],
})
export class ToastComponent {
  @Input() message: string = '';
  @Input() hide_timeut: number = 5; // in seconds
  show_toast: boolean = false;
  timeout_id: any;

  show() {
    this.show_toast = true;
    this.timeout_id = setTimeout(() => {
      this.show_toast = false;
    }, this.hide_timeut * 1000);
  }

  hide() {
    this.show_toast = false;
    clearTimeout(this.timeout_id);
  }
}
