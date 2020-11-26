import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { forkJoin } from 'rxjs';
import { BaseEditorComponent, EditorData } from '../base-editor/base-editor.component';
import { MessageDialogComponent, MessageDialogData } from '../message-dialog/message-dialog.component';
import { RestBaseService } from '../../rest-base.service';

@Component({
  selector: 'app-base-table-view',
  templateUrl: './base-table-view.component.html',
  styleUrls: ['./base-table-view.component.css']
})
export class BaseTableViewComponent implements OnInit {
  @Input() service: RestBaseService<any>;
  @Input() tableHeader: string;
  @Input() editorTitle: string;
  @Input() createItem: () => object;
  @Input() getId: (item: object) => number;

  isLoading: boolean;
  items: Array<any>;
  displayedColumns: Array<string>;
  columnDefinitions: Array<ColumnDefinition>

  constructor(private dialog: MatDialog) { }

  ngOnInit(): void {
    this.isLoading = true;
    forkJoin(this.service.get(), this.service.getColumnMetadata())
      .subscribe(res => {
        this.items = res[0];
        this.columnDefinitions = res[1];
        this.displayedColumns = this.columnDefinitions.map(c => c.key).concat(['edit', 'delete']);
        this.isLoading = false;
      });
  }

  onRowClick(row: any) {
    this.openEditor(row, false);
  }

  onRowEdit($event: any, row: any) {
    console.log("onRowEdit");
    $event.stopPropagation();

    this.openEditor(row, false);
  }

  onRowDelete($event: any, row: any) {
    console.log("onRowDelete");
    let data = <MessageDialogData>{
      message: 'Do you want to delete this record?',
      showCancelButton: false
    }
    this.dialog.open(MessageDialogComponent, { data: data });
    $event.stopPropagation()
  }

  onCreate() {
    console.log("onCreate");
  }

  private openEditor(row: any, isNew: boolean) : void {
    let data = <EditorData>{
      dialogTitle: this.editorTitle,
      columnDefinitions: this.columnDefinitions,
      item: row,
      saveEvent: item => isNew
        ? this.service.post(item).subscribe(_ => this.reload())
        : this.service.put(this.getId(item), item).subscribe(_ => this.reload())
      };
    let dialogRef = this.dialog.open(BaseEditorComponent, { data: data });
  }

  private reload(): void {
    this.isLoading = true;

    this.service.get().subscribe(res => {
      this.items = res;
      this.isLoading = false;
    });
  }
}

export interface ColumnDefinition {
  header: string;
  key: string;
  //template: Component;
}
