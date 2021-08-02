import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CollectionService } from 'src/services/collection-service';

@Component({
  selector: 'app-collection-types',
  templateUrl: './collection-types.component.html',
  styleUrls: ['./collection-types.component.css']
})
export class CollectionTypesComponent implements OnInit {

  userId: number = 0;
  types!: string[];


  constructor(private service : CollectionService, private router : Router) { }

  ngOnInit(): void {
    let u = JSON.parse(localStorage.getItem('user') || '{}');
    this.userId = u.id;
    this.service.GetCollectionTypes(this.userId).subscribe((res: string[]) =>
      this.types = res);
  }

}
