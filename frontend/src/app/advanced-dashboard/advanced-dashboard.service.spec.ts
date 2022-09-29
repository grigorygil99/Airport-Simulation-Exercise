import { TestBed } from '@angular/core/testing';

import { AdvancedDashboardService } from './advanced-dashboard.service';

describe('AdvancedDashboardService', () => {
  let service: AdvancedDashboardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdvancedDashboardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
