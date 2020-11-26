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
  formGroup: FormGroup;

  constructor(@Inject(MAT_DIALOG_DATA) public data: EditorData, public dialogService: MatDialog, private formBuilder: FormBuilder) {
    let formGroupObj = {};
    this.data.columnDefinitions.forEach(c => formGroupObj[c.key] = this.data.item[c.key]);
    this.formGroup = this.formBuilder.group(formGroupObj);
  }

  ngOnInit(): void {
    
  }

  onSave() {
    this.data.columnDefinitions.forEach(c => {
      this.data.item[c.key] = this.formGroup.value[c.key];
    });
    this.data.saveEvent(this.data.item);
  }
}

export interface EditorData {
  dialogTitle: string;
  item: object;
  saveEvent: (item: any) => { };
  columnDefinitions: Array<ColumnDefinition>;
}
