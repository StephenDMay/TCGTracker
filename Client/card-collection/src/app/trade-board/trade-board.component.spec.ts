import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TradeBoardComponent } from './trade-board.component';

describe('TradeBoardComponent', () => {
  let component: TradeBoardComponent;
  let fixture: ComponentFixture<TradeBoardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TradeBoardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TradeBoardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
