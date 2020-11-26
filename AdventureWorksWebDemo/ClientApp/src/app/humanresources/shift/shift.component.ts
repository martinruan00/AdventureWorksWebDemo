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

  constructor(public service: ShiftService) {

  }

  ngOnInit(): void {
  }
}
