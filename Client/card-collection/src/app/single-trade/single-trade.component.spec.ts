import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SingleTradeComponent } from './single-trade.component';

describe('SingleTradeComponent', () => {
  let component: SingleTradeComponent;
  let fixture: ComponentFixture<SingleTradeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SingleTradeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SingleTradeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
