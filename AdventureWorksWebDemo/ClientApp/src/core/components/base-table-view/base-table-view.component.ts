import { Component, OnInit, Input, OnChanges, SimpleChanges, SimpleChange } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';

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

  displayedColumns: Array<string>;

  constructor(private dialog: MatDialog) { }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.columnDefinitions != undefined) {
      this.displayedColumns;
      this.displayedColumns = (changes.columnDefinitions.currentValue as Array<ColumnDefinition>)
        .map(c => c.key)
        .concat(['edit', 'delete']);
    }
  }

  ngOnInit(): void {
  }

  onRowClick(row: any) {
    console.log("onRowClick");
    this.rowClick?.emit(row);
  }

  onRowEdit($event: any, row: any) {
    console.log("onRowEdit");
    this.rowEdit?.emit(row);
    $event.stopPropagation()
  }

  onRowDelete($event: any, row: any) {
    console.log("onRowDelete");
    this.rowDelete?.emit(row);
    $event.stopPropagation()
  }

  onCreate() {
    console.log("onCreate");
    this.create?.emit();
  }
}

export interface ColumnDefinition {
  header: string;
  key: string;
  //template: Component;
}
