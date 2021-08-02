import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CollectionBySetComponent } from './collection-by-set.component';

describe('CollectionBySetComponent', () => {
  let component: CollectionBySetComponent;
  let fixture: ComponentFixture<CollectionBySetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CollectionBySetComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CollectionBySetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
