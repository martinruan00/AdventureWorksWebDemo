import { Component, OnInit } from '@angular/core';
import { JobCandidate } from '../../../model/humanresources/job-candidate';
import { JobcandidateService } from '../../../service/humanresources/jobcandidate.service';

@Component({
  selector: 'app-job-candidate',
  templateUrl: './job-candidate.component.html',
  styleUrls: ['./job-candidate.component.css']
})
export class JobCandidateComponent implements OnInit {
  displayedColumns: String[] = ['businessEntityId', 'resume'];
  jobCandidates: JobCandidate[];

  constructor(private service: JobcandidateService) { }

  ngOnInit(): void {
    this.service.get().subscribe(response => {
      this.jobCandidates = response;
    });
  }
}
