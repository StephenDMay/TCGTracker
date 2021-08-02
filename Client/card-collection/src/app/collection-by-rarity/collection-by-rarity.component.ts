import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { card } from 'src/models/card';
import { CollectionService } from 'src/services/collection-service';

@Component({
  selector: 'app-collection-by-rarity',
  templateUrl: './collection-by-rarity.component.html',
  styleUrls: ['./collection-by-rarity.component.css']
})
export class CollectionByRarityComponent implements OnInit {

  userId!: number;
  rarity!: string;
  cards!: card[];
  count!: number;

  constructor(private service : CollectionService, private router: ActivatedRoute) { }

  ngOnInit(): void {
    let u = JSON.parse(localStorage.getItem('user') || '{}');
    this.userId = u.id;
    this.rarity = this.router.snapshot.params['rarity']
    this.service.getCollectionByRarity(this.userId, this.rarity).subscribe(res => {
      this.cards = res;
      this.count = res.length;
    })
  }

}
