import { Component, OnInit } from '@angular/core';
import { ShiftService } from '../../../service/humanresources/shift.service';
import { Shift } from '../../../model/humanresources/shift';
import { ColumnDefinition } from '../../../core/components/base-table-view/base-table-view.component';

@Component({
  selector: 'app-shift',
  templateUrl: './shift.component.html',
  styleUrls: ['./shift.component.css']
})
export class ShiftComponent implements OnInit {
  loading: boolean;
  displayedColumns: String[] = ['name', 'startTime', 'endTime'];
  shifts: Shift[];
  columnDefinitions: Array<ColumnDefinition> = [
    { header: 'Name', key: 'name' },
    { header: 'Start time', key: 'startTime' },
    { header: 'End time', key: 'endTime' }
  ];

  constructor(private service: ShiftService) {

  }

  ngOnInit(): void {
    this.loading = true;
    this.service.get().subscribe(response => {
      this.shifts = response;
      this.loading = false;
    });
  }
}
