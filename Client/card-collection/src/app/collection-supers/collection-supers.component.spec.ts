import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CollectionSupersComponent } from './collection-supers.component';

describe('CollectionSupersComponent', () => {
  let component: CollectionSupersComponent;
  let fixture: ComponentFixture<CollectionSupersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CollectionSupersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CollectionSupersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
