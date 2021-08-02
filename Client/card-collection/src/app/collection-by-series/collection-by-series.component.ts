import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { set } from 'src/models/set';
import { CardService } from 'src/services/card-service';
import { SeriesListComponent } from '../series-list/series-list.component';

@Component({
  selector: 'app-collection-by-series',
  templateUrl: './collection-by-series.component.html',
  styleUrls: ['./collection-by-series.component.css']
})
export class CollectionBySeriesComponent implements OnInit {

  @Input() series!: string;
  sets!: set[];

  constructor(private service : CardService, private router : ActivatedRoute) { }

  ngOnInit(): void {
    this.series = this.router.snapshot.params['series'];
    this.service.getSetsBySeries(this.series).subscribe(result => {
      this.sets = result;
    });
  }

}
