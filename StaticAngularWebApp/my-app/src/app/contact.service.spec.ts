import { TestBed } from '@angular/core/testing';

import { ContactAPIService } from './contact.service';

describe('ContactAPIService', () => {
  let service: ContactAPIService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ContactAPIService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
