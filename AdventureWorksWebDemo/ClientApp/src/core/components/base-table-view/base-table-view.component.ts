import { Component, OnInit, Input, OnChanges, SimpleChanges, SimpleChange } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseEditorComponent, EditorData } from '../base-editor/base-editor.component';
import { MessageDialogComponent, MessageDialogData } from '../message-dialog/message-dialog.component';

@Component({
  selector: 'app-base-table-view',
  templateUrl: './base-table-view.component.html',
  styleUrls: ['./base-table-view.component.css']
})
export class BaseTableViewComponent implements OnInit, OnChanges {
  @Input() loading: boolean;
  @Input() items: Array<any>;
  @Input() columnDefinitions: Array<ColumnDefinition>;
  @Input() rowClick: EventEmitter<any>;
  @Input() rowEdit: EventEmitter<any>;
  @Input() rowDelete: EventEmitter<any>;
  @Input() create: EventEmitter<any>;
  @Input() tableHeader: string;
  @Input() editorTitle: string;

  displayedColumns: Array<string>;

  constructor(private dialog: MatDialog) { }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.columnDefinitions?.currentValue != undefined) {
      this.displayedColumns = (changes.columnDefinitions.currentValue as Array<ColumnDefinition>)
        .map(c => c.key)
        .concat(['edit', 'delete']);
    }
  }

  ngOnInit(): void {
  }

  onRowClick(row: any) {
    this.openEditor(row);
    this.rowClick?.emit(row);
  }

  onRowEdit($event: any, row: any) {
    console.log("onRowEdit");
    this.rowEdit?.emit(row);
    $event.stopPropagation();

    this.openEditor(row);
  }

  onRowDelete($event: any, row: any) {
    console.log("onRowDelete");
    let data = <MessageDialogData>{
      message: 'Do you want to delete this record?',
      showCancelButton: false
    }
    this.dialog.open(MessageDialogComponent, { data: data });
    this.rowDelete?.emit(row);
    $event.stopPropagation()
  }

  onCreate() {
    console.log("onCreate");
    this.create?.emit();
  }

  private openEditor(row: any) {
    let data = <EditorData>{
      dialogTitle: this.editorTitle,
      columnDefinitions: this.columnDefinitions,
      item: row,
      saveEvent: null
      };
    let dialogRef = this.dialog.open(BaseEditorComponent, { data: data });
  }
}

export interface ColumnDefinition {
  header: string;
  key: string;
  //template: Component;
}
