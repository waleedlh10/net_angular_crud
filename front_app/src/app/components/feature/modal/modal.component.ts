import { Component } from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss'],
})
export class ModalComponent {
  show: boolean = true;

  hide() {
    this.show = false;
  }

  save() {
    this.hide();
  }
}
