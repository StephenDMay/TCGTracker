import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { card } from 'src/models/card';
import { CollectionService } from 'src/services/collection-service';

@Component({
  selector: 'app-collection-all',
  templateUrl: './collection-all.component.html',
  styleUrls: ['./collection-all.component.css']
})
export class CollectionAllComponent implements OnInit {


  userId: number = 0;
  cards!: card[];
  name: string = "All Cards in Your Collection"
  
  constructor(private service : CollectionService, private router: Router) 
  {
    
   }

  ngOnInit(): void {
    let u = JSON.parse(localStorage.getItem('user') || '{}');
    this.userId = u.id;
    this.service.getCollection(this.userId).subscribe(res => {
      this.cards = res;
    })
  }

}
