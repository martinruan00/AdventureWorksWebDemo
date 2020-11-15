import { Component, OnInit, Input, OnChanges, SimpleChanges, SimpleChange } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-base-table-view',
  templateUrl: './base-table-view.component.html',
  styleUrls: ['./base-table-view.component.css']
})
export class BaseTableViewComponent implements OnInit, OnChanges {
  @Input() loading: boolean;
  @Input() items: Array<any>;
  @Input() columnDefinitions: Array<ColumnDefinition>;

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

}

export interface ColumnDefinition {
  header: string;
  key: string;
  template: Component;
}
