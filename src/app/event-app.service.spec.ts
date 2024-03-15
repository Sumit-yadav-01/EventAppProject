import { TestBed } from '@angular/core/testing';

import { EventAppService } from './event-app.service';

describe('EventAppService', () => {
  let service: EventAppService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EventAppService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
