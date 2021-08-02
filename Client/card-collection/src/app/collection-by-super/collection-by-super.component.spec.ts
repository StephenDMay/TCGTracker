import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CollectionBySuperComponent } from './collection-by-super.component';

describe('CollectionBySuperComponent', () => {
  let component: CollectionBySuperComponent;
  let fixture: ComponentFixture<CollectionBySuperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CollectionBySuperComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CollectionBySuperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
