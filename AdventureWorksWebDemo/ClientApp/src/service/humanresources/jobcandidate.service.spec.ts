import { TestBed } from '@angular/core/testing';

import { JobcandidateService } from './jobcandidate.service';

describe('JobcandidateService', () => {
  let service: JobcandidateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JobcandidateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
