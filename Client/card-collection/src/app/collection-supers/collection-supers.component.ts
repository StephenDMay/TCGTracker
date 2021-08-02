import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-collection-supers',
  templateUrl: './collection-supers.component.html',
  styleUrls: ['./collection-supers.component.css']
})
export class CollectionSupersComponent implements OnInit {

  supers: string[] = ['Pokémon', 'Trainer', 'Energy'];


  constructor() { }

  ngOnInit(): void {
  }

}
