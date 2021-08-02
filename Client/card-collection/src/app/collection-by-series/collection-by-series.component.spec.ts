import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CollectionBySeriesComponent } from './collection-by-series.component';

describe('CollectionBySeriesComponent', () => {
  let component: CollectionBySeriesComponent;
  let fixture: ComponentFixture<CollectionBySeriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CollectionBySeriesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CollectionBySeriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
