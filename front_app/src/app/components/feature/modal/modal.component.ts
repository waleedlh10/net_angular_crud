import {
  Component,
  ElementRef,
  EventEmitter,
  Input,
  Output,
  ViewChild,
} from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss'],
})
export class ModalComponent {
  @ViewChild('modal', { static: false }) modal!: ElementRef;
  @Input() title!: string;
  @Input() bodyContent!: string;
  show_modal: boolean = false;
  @Output() confirmed = new EventEmitter<void>();

  constructor() {}

  show(): void {
    this.show_modal = true;
  }

  hide(): void {
    this.show_modal = false;
  }

  confirm() {
    this.confirmed.emit();
    this.hide();
  }
}
