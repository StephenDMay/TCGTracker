import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CollectionAllComponent } from './collection-all.component';

describe('CollectionAllComponent', () => {
  let component: CollectionAllComponent;
  let fixture: ComponentFixture<CollectionAllComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CollectionAllComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CollectionAllComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
