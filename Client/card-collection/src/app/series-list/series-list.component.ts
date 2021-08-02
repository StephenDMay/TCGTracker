import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CardService } from 'src/services/card-service';

@Component({
  selector: 'app-series-list',
  templateUrl: './series-list.component.html',
  styleUrls: ['./series-list.component.css']
})
export class SeriesListComponent implements OnInit {

  series! : string[];

  constructor(private service : CardService, private router: Router) { }

  ngOnInit(): void {
    this.service.getAllSeries().subscribe(result => {
      this.series = result;

    })
  }

}
