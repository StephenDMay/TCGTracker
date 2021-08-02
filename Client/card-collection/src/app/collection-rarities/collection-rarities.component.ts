import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CollectionService } from 'src/services/collection-service';

@Component({
  selector: 'app-collection-rarities',
  templateUrl: './collection-rarities.component.html',
  styleUrls: ['./collection-rarities.component.css']
})
export class CollectionRaritiesComponent implements OnInit {

  userId: number = 0;
  rarities!: string[];

  constructor(private service : CollectionService, private router : Router) { }

  ngOnInit(): void {
    let u = JSON.parse(localStorage.getItem('user') || '{}');
    this.userId = u.id;
    this.service.GetCollectionRarities(this.userId).subscribe((res: string[]) =>
      this.rarities = res);
  }

}
