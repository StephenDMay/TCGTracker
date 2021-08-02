import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CollectionRaritiesComponent } from './collection-rarities.component';

describe('CollectionRaritiesComponent', () => {
  let component: CollectionRaritiesComponent;
  let fixture: ComponentFixture<CollectionRaritiesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CollectionRaritiesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CollectionRaritiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
