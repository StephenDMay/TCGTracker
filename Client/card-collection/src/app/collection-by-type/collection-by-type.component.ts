import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { card } from 'src/models/card';
import { CollectionService } from 'src/services/collection-service';

@Component({
  selector: 'app-collection-by-type',
  templateUrl: './collection-by-type.component.html',
  styleUrls: ['./collection-by-type.component.css']
})
export class CollectionByTypeComponent implements OnInit {

  userId!: number;
  type!: string;
  cards!: card[];
  count!: number;

  constructor(private service : CollectionService, private router: ActivatedRoute) { }

  ngOnInit(): void {
    let u = JSON.parse(localStorage.getItem('user') || '{}');
    this.userId = u.id;
    this.type = this.router.snapshot.params['type']
    this.service.getCollectionByType(this.userId, this.type).subscribe(res => {
      this.cards = res;
      this.count = res.length;
    })
  }

}
