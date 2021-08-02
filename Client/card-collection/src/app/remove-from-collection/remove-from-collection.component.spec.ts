import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoveFromCollectionComponent } from './remove-from-collection.component';

describe('RemoveFromCollectionComponent', () => {
  let component: RemoveFromCollectionComponent;
  let fixture: ComponentFixture<RemoveFromCollectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RemoveFromCollectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RemoveFromCollectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
