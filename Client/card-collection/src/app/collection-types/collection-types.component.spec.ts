import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CollectionTypesComponent } from './collection-types.component';

describe('CollectionTypesComponent', () => {
  let component: CollectionTypesComponent;
  let fixture: ComponentFixture<CollectionTypesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CollectionTypesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CollectionTypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
