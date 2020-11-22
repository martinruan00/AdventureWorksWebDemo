import { Component, OnInit, Input, EventEmitter, OnChanges, SimpleChanges, Inject } from '@angular/core';
import { ColumnDefinition } from '../base-table-view/base-table-view.component';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-base-editor',
  templateUrl: './base-editor.component.html',
  styleUrls: ['./base-editor.component.css']
})
export class BaseEditorComponent implements OnInit {
  item: object
  columnDefinitions: Array<ColumnDefinition>;
  saveEvent: EventEmitter<any>;
  formGroup: FormGroup;

  constructor(@Inject(MAT_DIALOG_DATA) public data: EditorData, public dialogService: MatDialog, private formBuilder: FormBuilder) {
    this.item = data.item;
    this.columnDefinitions = data.columnDefinitions;

    let formGroupObj = {};
    this.columnDefinitions.forEach(c => formGroupObj[c.key] = this.item[c.key]);
    this.formGroup = this.formBuilder.group(formGroupObj);
  }

  ngOnInit(): void {
    
  }

  onSave() {
    this.columnDefinitions.forEach(c => this.item[c.key] = this.formGroup[c.key]);
    this.saveEvent?.emit(this.item);
  }
}

export interface EditorData {
  dialogTitle: string;
  item: object;
  saveEvent: EventEmitter<any>;
  columnDefinitions: Array<ColumnDefinition>;
}
