import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { card } from 'src/models/card';
import { set } from 'src/models/set';
import { CardService } from 'src/services/card-service';

@Component({
  selector: 'app-card-list',
  templateUrl: './card-list.component.html',
  styleUrls: ['./card-list.component.css']
})
export class CardListComponent implements OnInit {

  @Input() id!: string;
  @Input() image!: string;
  set!: set;
  
  cards!: card[];

  constructor(private service : CardService, private router : ActivatedRoute) { }

  ngOnInit(): void {
    this.id = this.router.snapshot.params['id'];
    this.service.getCardsBySet(this.id).subscribe(result => {
      this.cards = result;

    })

    this.service.getSetById(this.id).subscribe(res => {
      this.set = res;
    })
  }
}
