import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-message-dialog',
  templateUrl: './message-dialog.component.html',
  styleUrls: ['./message-dialog.component.css']
})
export class MessageDialogComponent implements OnInit {
  result: boolean;

  constructor(@Inject(MAT_DIALOG_DATA) public data: MessageDialogData) { }

  ngOnInit(): void {
  }
}

export interface MessageDialogData {
  message: string;
  showCancelButton: boolean;
}
