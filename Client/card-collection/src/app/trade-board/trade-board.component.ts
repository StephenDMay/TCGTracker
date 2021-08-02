import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { trade } from 'src/models/trade';
import { TradeService } from 'src/services/trade-service';

@Component({
  selector: 'app-trade-board',
  templateUrl: './trade-board.component.html',
  styleUrls: ['./trade-board.component.css']
})
export class TradeBoardComponent implements OnInit {

  allTrades!: trade[];
  

  constructor(private service : TradeService, private router : Router) 
  {

   }

  ngOnInit(): void {
    this.service.getAllTrades().subscribe(res => {
      this.allTrades = res;
    })
    
  }

}
