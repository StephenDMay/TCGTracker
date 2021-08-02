import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CollectionService } from 'src/services/collection-service';

@Component({
  selector: 'app-remove-from-collection',
  templateUrl: './remove-from-collection.component.html',
  styleUrls: ['./remove-from-collection.component.css']
})
export class RemoveFromCollectionComponent implements OnInit {

  userId: number = 0;
  @Input() cardId!: string;
  
  constructor(private service : CollectionService, private router : ActivatedRoute) { }

  ngOnInit(): void {
    this.cardId = this.router.snapshot.params['id'];
    let u = JSON.parse(localStorage.getItem('user') || '{}');
    this.userId = u.id;
  }

  removeFromCollection() {
    console.log("Removing from collection " + this.userId + " card " + this.cardId)
    this.service.removeFromCollection(this.cardId).subscribe();
  }

  reload(){
    // any other execution
    this.ngOnInit()
    }

}
