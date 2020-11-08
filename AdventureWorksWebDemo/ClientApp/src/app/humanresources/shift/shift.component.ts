import { Component, OnInit } from '@angular/core';
import { ShiftService } from '../../../service/humanresources/shift.service';
import { Shift } from '../../../model/humanresources/shift';

@Component({
  selector: 'app-shift',
  templateUrl: './shift.component.html',
  styleUrls: ['./shift.component.css']
})
export class ShiftComponent implements OnInit {
  displayedColumns: String[] = ['name', 'startTime', 'endTime'];
  shifts: Shift[];

  constructor(private service: ShiftService) { }

  ngOnInit(): void {
    this.service.get().subscribe(response => {
      this.shifts = response;
    });
  }
}
