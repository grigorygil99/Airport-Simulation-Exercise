import { TestBed } from '@angular/core/testing';

import { NormalDashboardService } from './normal-dashboard.service';

describe('NormalDashboardService', () => {
  let service: NormalDashboardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NormalDashboardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
