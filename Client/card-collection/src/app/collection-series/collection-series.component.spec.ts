import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CollectionSeriesComponent } from './collection-series.component';

describe('CollectionSeriesComponent', () => {
  let component: CollectionSeriesComponent;
  let fixture: ComponentFixture<CollectionSeriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CollectionSeriesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CollectionSeriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
