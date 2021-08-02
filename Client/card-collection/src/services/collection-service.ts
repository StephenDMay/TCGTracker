import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, of } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { card } from "src/models/card";


@Injectable({
    providedIn: 'root'
})
export class CollectionService{
    
    
    
    url: string = "https://localhost:44345/"

    httpOptions = {headers: new HttpHeaders({"Content-Type" : "application/json"})}
    
    userId : number;
    card!: card;
    result!: card;


    constructor(private http : HttpClient, private router :Router ) {
        let u = JSON.parse(localStorage.getItem('user')  || '{}');
        this.userId = u.id;
     }
  
    getCollection(userId: number) : Observable<card[]>{
        return this.http.get<card[]>(this.url +"User/" + userId + "/Collection")
        .pipe(
            tap(),
            catchError(err => {
                console.log(err);
                let empty : card[] = [];
                return of(empty)
            })
        )
    }

    addToCollection(card : string) 
    {
      return this.http.post(this.url + "User/" + this.userId + "/Collection/Add/" + card, card, this.httpOptions).pipe(
          tap(),
          catchError(err => {
            alert(err.error);
            return of(null);
          })
      );
    }
     
    getSetTotal(setId : string) {
      return this.http.get<number>(this.url + "User/" + this.userId + "/Collection/" + setId + "/Max")
    }
    
    getSetCount(setId : string)  {
      return this.http.get<number>(this.url + "User/" + this.userId + "/Collection/" + setId + "/Count")
    }


    GetCollectionTypes(userId: number) : Observable<string[]> {
      return this.http.get<string[]>(this.url + "Collection/" + this.userId + "/allTypes" );
    }

    getCollectionByType(userId: number, type: string) {
      return this.http.get<card[]>(this.url + "Collection/" + userId + "/" + type);
    }

    getCollectionBySuper(userId: number, s: string) {
      return this.http.get<card[]>(this.url + "Collection/" + userId + "/superType/" + s)
    }

    GetCollectionRarities(userId: number) : Observable<string[]> {
      return this.http.get<string[]>(this.url +"Collection/" + userId + "/allRarities" );
    }

    getCollectionByRarity(userId: number, rarity: string) {
      return this.http.get<card[]>(this.url + "Collection/" + userId + "/rarity/" + rarity)
    }

    GetCollectionSeries(userId: number) {
      return this.http.get<string[]>(this.url +"Collection/" + this.userId + "/allSeries" );
    }

    removeFromCollection(cardId: string) {
      return this.http.delete<card>(this.url + "User/" + this.userId + "/Collection/Remove/" + cardId);
    }

   
    
  }