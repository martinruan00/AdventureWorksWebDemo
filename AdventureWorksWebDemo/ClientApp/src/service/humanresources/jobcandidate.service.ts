import { Injectable } from '@angular/core';
import { JobCandidate } from '../../model/humanresources/job-candidate';
import { RestBaseService } from '../../core/rest-base.service';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../../core/config.service';

@Injectable({
  providedIn: 'root'
})
export class JobcandidateService extends RestBaseService<JobCandidate> {

  constructor(http: HttpClient, configService: ConfigService) {
    super(http, configService);
  }

  protected getApiPath(): string {
    return "jobcandidates";
  }
}
