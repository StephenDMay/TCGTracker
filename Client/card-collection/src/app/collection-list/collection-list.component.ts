import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { card } from 'src/models/card';
import { CollectionService } from 'src/services/collection-service';

@Component({
  selector: 'app-collection-list',
  templateUrl: './collection-list.component.html',
  styleUrls: ['./collection-list.component.css']
})
export class CollectionListComponent implements OnInit {


  userId: number = 0;
  @Input()cards!: card[];
  @Input() name!: string;
  
  constructor(private service : CollectionService, private router: Router) 
  {
    
   }

  ngOnInit(): void {
    
  }

}
