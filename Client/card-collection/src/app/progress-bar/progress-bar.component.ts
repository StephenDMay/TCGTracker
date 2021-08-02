import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { count } from 'rxjs/operators';
import { set } from 'src/models/set';
import { CollectionService } from 'src/services/collection-service';

@Component({
  selector: 'app-progress-bar',
  templateUrl: './progress-bar.component.html',
  styleUrls: ['./progress-bar.component.css']
})
export class ProgressBarComponent implements OnInit {

  
  
  @Input() id!: string;
  cardCount!: number;
  max: number = 0;
  progress!: number;
  proString: string = "";
  
  constructor(private service : CollectionService, private router : Router) {
    
   }

  ngOnInit(): void {
    this.service.getSetCount(this.id).subscribe(res => {
        this.cardCount = res;
      });
      this.service.getSetTotal(this.id).subscribe(res => {
        this.max = res;
      });

      
  }

  getProgress() : number {
    return this.cardCount / this.max;
  }

 
  

 
}
