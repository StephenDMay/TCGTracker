import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SetTrackerComponent } from './set-tracker.component';

describe('SetTrackerComponent', () => {
  let component: SetTrackerComponent;
  let fixture: ComponentFixture<SetTrackerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SetTrackerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SetTrackerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
