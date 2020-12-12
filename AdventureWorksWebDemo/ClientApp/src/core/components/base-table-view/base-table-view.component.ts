import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { forkJoin } from 'rxjs';
import { BaseEditorComponent, EditorData } from '../base-editor/base-editor.component';
import { MessageDialogComponent, MessageDialogData } from '../message-dialog/message-dialog.component';
import { RestBaseService } from '../../rest-base.service';
import { PageEvent } from '@angular/material/paginator';

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
  currentPageItems: Array<any>;
  displayedColumns: Array<string>;
  columnDefinitions: Array<ColumnDefinition>
  pageSize: number = 10;

  constructor(private dialog: MatDialog) { }

  ngOnInit(): void {
    this.isLoading = true;
    forkJoin(this.service.get(), this.service.getColumnMetadata())
      .subscribe(
        responses => {
          this.items = responses[0];
          this.currentPageItems = this.items.slice(0, this.pageSize);
          this.columnDefinitions = responses[1];
          this.displayedColumns = this.columnDefinitions.map(c => c.key).concat(['edit', 'delete']);
        },
        err => {

        },
        () => this.isLoading = false);
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
    $event.stopPropagation()

    const data = <MessageDialogData>{
      message: 'Do you want to delete this record?',
      showCancelButton: false
    }
    const dialogRef = this.dialog.open(MessageDialogComponent, { data: data });
    dialogRef.afterClosed()
      .subscribe(_ => {
        if (dialogRef.componentInstance.result) {
          this.service.delete(row)
            .subscribe(
              res => { console.log('Deleted'); },
              error => { console.log('Can not delete due to exception ' + error); });
        }
      });
    
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
        : this.service.put(item).subscribe(_ => this.reload())
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

  onPageChanged(env: PageEvent): void {
    this.currentPageItems = this.items.slice(env.pageIndex * env.pageSize, env.pageIndex * env.pageSize + env.pageSize);
  }
}

export interface ColumnDefinition {
  header: string;
  key: string;
  //template: Component;
}
