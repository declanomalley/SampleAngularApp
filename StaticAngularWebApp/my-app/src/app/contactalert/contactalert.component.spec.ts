import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactalertComponent } from './contactalert.component';

describe('ContactalertComponent', () => {
  let component: ContactalertComponent;
  let fixture: ComponentFixture<ContactalertComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContactalertComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactalertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
