import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { set } from 'src/models/set';
import { CardService } from 'src/services/card-service';

@Component({
  selector: 'app-set-tracker',
  templateUrl: './set-tracker.component.html',
  styleUrls: ['./set-tracker.component.css']
})
export class SetTrackerComponent implements OnInit {

  @Input() series!: string

  sets!: set[];

  constructor(private service : CardService, private router: Router) { }


  ngOnInit(): void {
    this.service.getSetsBySeries(this.series).subscribe(result => {
      this.sets = result;
  });

  }
  print(s : string) : void {
    console.log(s)
  }
}
