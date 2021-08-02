import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { card } from 'src/models/card';
import { trade } from 'src/models/trade';
import { User } from 'src/models/user';
import { CardService } from 'src/services/card-service';
import { CollectionService } from 'src/services/collection-service';
import { TradeService } from 'src/services/trade-service';
import { TradeBoardComponent } from '../trade-board/trade-board.component';

@Component({
  selector: 'app-trade-request',
  templateUrl: './trade-request.component.html',
  styleUrls: ['./trade-request.component.css']
})
export class TradeRequestComponent implements OnInit {

  @Input()
  cardId!: string;
  userId: number = 0;
  card!: card;
  offer!: card;
  cards!: card[];
  offerList: card[] = [];
  choice: string = '';
  t !: trade;
  user!: User;
  requestList: card[] = [];

  constructor(private service : TradeService, private cardService : CardService, private colService : CollectionService, private router : ActivatedRoute) { }


  ngOnInit(): void {
    this.cardId = this.router.snapshot.params['cardId'];
    this.cardService.getCardById(this.cardId).subscribe(result => {
      this.card = result;

    });
    this.user = JSON.parse(localStorage.getItem('user') || '{}');
    this.userId = parseInt(this.user.id);
    this.colService.getCollection(this.userId).subscribe(res => {
      this.cards = res;
    })

  }

  selectChangedHandler (event: any) {
    this.choice = event.target.value;
    this.offer = this.cards.filter(c => c.name == this.choice)[0];
  }

  createTrade(toOffer : card) {
    
    this.offerList.push(toOffer);
   this.service.createTrade(this.offerList).subscribe(res => {
     this.t = res;
   });
   
  }

  createRequest(c : card) {
    this.requestList.push(c);
    this.service.createRequest(this.requestList).subscribe();


  }

}
