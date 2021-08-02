import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { card } from 'src/models/card';
import { CardService } from 'src/services/card-service';
import { CollectionService } from 'src/services/collection-service';

@Component({
  selector: 'app-card-detail',
  templateUrl: './card-detail.component.html',
  styleUrls: ['./card-detail.component.css']
})
export class CardDetailComponent implements OnInit {

  @Input()
  cardId!: string;

  card!: card;
  userId: number = 0;
  cards!: card[];
  owned: boolean = false;

  constructor(private service : CardService, private collService : CollectionService, private router : ActivatedRoute) { }

  ngOnInit(): void {
    let u = JSON.parse(localStorage.getItem('user') || '{}');
    this.userId = u.id;
    this.collService.getCollection(this.userId).subscribe(res => {
      this.cards = res;
    });
    
    this.cardId = this.router.snapshot.params['id'];
    this.service.getCardById(this.cardId).subscribe(result => {
      this.card = result;

    });
    
  }
  
  cardInCollection()  {
    for(let i = 0; i < this.cards.length; i++){
      if (this.cards[i].id == this.cardId) {
        return true;
      }
      
    }
    return false;
  }

  

  

  

}
