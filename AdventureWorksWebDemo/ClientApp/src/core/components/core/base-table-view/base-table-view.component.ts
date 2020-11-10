import { Component, OnInit, Input, OnChanges, SimpleChanges, SimpleChange } from '@angular/core';

@Component({
  selector: 'app-base-table-view',
  templateUrl: './base-table-view.component.html',
  styleUrls: ['./base-table-view.component.css']
})
export class BaseTableViewComponent implements OnInit, OnChanges {
  @Input() items: Array<any>;
  @Input() columnDefinitions: Array<ColumnDefinition>;
  displayedColumns: Array<string>;
  constructor() { }

  ngOnChanges(changes: SimpleChanges): void {
    this.displayedColumns = (changes.columnDefinitions.currentValue as Array<ColumnDefinition>).map(c => c.key);
  }

  ngOnInit(): void {
  }

}

export interface ColumnDefinition {
  header: string;
  key: string;
}
