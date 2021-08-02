import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { card } from "src/models/card";
import {tap, catchError, map} from 'rxjs/operators';
import { Observable, of, pipe } from 'rxjs';
import { set } from "src/models/set";

@Injectable({
    providedIn: 'root'
})
export class CardService {
    
    
    url: string = "https://localhost:44345/"

    httpOptions = {headers: new HttpHeaders({"Content-Type" : "application/json"})}

    result!: card;

    constructor(private http : HttpClient) { }


    getCardById(id : string) : Observable<card> {
        return this.http.get<card>(this.url + "Cards/" + id)
        .pipe(
            tap(),
            catchError(err => {
                console.log(err);
                return of(this.result);
            })
        )
    }

    getCardsBySet(set : string) : Observable<card[]> {
        return this.http.get<card[]>(this.url + "Cards/Set/" + set)
        .pipe(
            tap(),
            catchError(err => {
                console.log(err);
                let empty : card[] = [];
                return of(empty)
            })
        )
    }

    getAllSeries() : Observable<string[]> {
        return this.http.get<string[]>(this.url + "Sets/Series")
        .pipe(
            tap(),
            catchError(err => {
                console.log(err);
                let empty : string[] = [];
                return of(empty)
            })
        )
    }

    getSetsBySeries(series : string) : Observable<set[]> {
        return this.http.get<set[]>(this.url + "Sets/" + series)
        .pipe(
            tap(),
            catchError(err => {
                console.log(err);
                let empty : set[] = [];
                return of(empty)
            })
        )
    }

    getCardByName(name : string) : Observable<card> {
        return this.http.get<card>(this.url + "Cards/name/" + name)
        .pipe(
            tap(),
            catchError(err => {
                console.log(err);
                return of(this.result);
            })
        )
    }

    getSetById(id: string) {
        return this.http.get<set>(this.url + "Sets/Get/" + id);
      }

    
    
}