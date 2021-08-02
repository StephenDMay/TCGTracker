import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CollectionService } from 'src/services/collection-service';

@Component({
  selector: 'app-collection-series',
  templateUrl: './collection-series.component.html',
  styleUrls: ['./collection-series.component.css']
})
export class CollectionSeriesComponent implements OnInit {

  userId!: number;
  allSeries!: string[];


  constructor(private service : CollectionService, private router : Router) { }

  ngOnInit(): void {
    let u = JSON.parse(localStorage.getItem('user') || '{}');
    this.userId = u.id;
    this.service.GetCollectionSeries(this.userId).subscribe((res: string[]) =>
      this.allSeries = res);
  }

}
