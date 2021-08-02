import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CollectionByRarityComponent } from './collection-by-rarity.component';

describe('CollectionByRarityComponent', () => {
  let component: CollectionByRarityComponent;
  let fixture: ComponentFixture<CollectionByRarityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CollectionByRarityComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CollectionByRarityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
