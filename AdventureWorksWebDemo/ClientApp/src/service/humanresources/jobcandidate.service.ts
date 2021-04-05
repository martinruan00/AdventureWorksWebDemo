import { Injectable } from '@angular/core';
import { JobCandidate } from '../../model/humanresources/job-candidate';
import { RestBaseService } from '../../core/rest-base.service';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../../core/config.service';
import { Store } from '@ngrx/store';
import { AppState } from '../../app/app.reducer';

@Injectable({
  providedIn: 'root'
})
export class JobcandidateService extends RestBaseService<JobCandidate> {
  

  constructor(http: HttpClient, store: Store<AppState>) {
    super(http, store);
  }

  protected getApiPath(): string {
    return "jobcandidates";
  }

  protected getId(model: JobCandidate): number {
    return model.businessEntityId;
  }
}
