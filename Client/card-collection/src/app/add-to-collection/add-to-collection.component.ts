import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CollectionService } from 'src/services/collection-service';

@Component({
  selector: 'app-add-to-collection',
  templateUrl: './add-to-collection.component.html',
  styleUrls: ['./add-to-collection.component.css']
})
export class AddToCollectionComponent implements OnInit {
 
  userId: number = 0;
  @Input() cardId!: string;


  constructor(private service : CollectionService, private router : ActivatedRoute) { }

  ngOnInit(): void {
    this.cardId = this.router.snapshot.params['id'];
    let u = JSON.parse(localStorage.getItem('user') || '{}');
    this.userId = u.id;
  }

  addToCollection() {
    
    this.cardId = this.router.snapshot.params['id'];
    let u = JSON.parse(localStorage.getItem('user') || '{}');
    this.userId = u.id;
    console.log("Adding to " + this.userId + " card " + this.cardId)
    this.service.addToCollection(this.cardId).subscribe();
  }

  reload(){
    // any other execution
    this.ngOnInit()
    }

}
