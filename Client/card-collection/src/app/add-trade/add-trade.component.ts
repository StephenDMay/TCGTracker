import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-trade',
  templateUrl: './add-trade.component.html',
  styleUrls: ['./add-trade.component.css']
})
export class AddTradeComponent implements OnInit {

  @Input() cardId!: string;

  constructor() { }

  ngOnInit(): void {
  }

}
