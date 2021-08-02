import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { card } from 'src/models/card';
import { CollectionService } from 'src/services/collection-service';

@Component({
  selector: 'app-collection-by-super',
  templateUrl: './collection-by-super.component.html',
  styleUrls: ['./collection-by-super.component.css']
})
export class CollectionBySuperComponent implements OnInit {

  userId!: number;
  super!: string;
  cards!: card[];
  count!: number;


  constructor(private service : CollectionService, private router: ActivatedRoute) { }
  
  ngOnInit(): void {
    let u = JSON.parse(localStorage.getItem('user') || '{}');
    this.userId = u.id;
    this.super = this.router.snapshot.params['super']
    this.service.getCollectionBySuper(this.userId, this.super).subscribe(res => {
      this.cards = res;
      this.count = res.length;
    })
  }

}
