import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, of } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { card } from "src/models/card";
import { trade } from "src/models/trade";
import { User } from "src/models/user";
import { request } from "src/models/request"

@Injectable({
    providedIn: 'root'
})
export class TradeService{
  
  
    url: string = "https://localhost:44345/"

    httpOptions = {headers: new HttpHeaders({"Content-Type" : "application/json"})}
    
    userId : number;
    req!: request;

    constructor(private http : HttpClient, private router :Router ) {
        let u = JSON.parse(localStorage.getItem('user')  || '{}');
        this.userId = u.id;
     }

     getAllTrades() : Observable<trade[]> {
        return this.http.get<trade[]>(this.url + "Trades")
        .pipe(
            tap(),
            catchError(err => {
                console.log(err);
                let empty : trade[] = [];
                return of(empty)
            }
        ))
      }

      getCardsByTradeId(tradeId: number) {
        return this.http.get<card[]>(this.url + "Trades/Cards/" + tradeId)
        .pipe(
            tap(),
            catchError(err => {
                console.log(err);
                let empty : card[] = [];
                return of(empty)
            }
        ))
      }

      getTradeUserName(tradeId: number) : Observable<User> {
        return this.http.get<User>(this.url + "Trades/" + tradeId + "/user")
        .pipe(
          tap(),
      )
      }

      createTrade(c : card[]) : Observable<any>{
        console.log(c);
        let u = JSON.parse(localStorage.getItem('user')  || '{}');
        let toAdd : trade = { id : 0, user : u, cardsOffered : c};

        return this.http.post<trade>(this.url + "Trades/Add/" + this.userId, toAdd, this.httpOptions);
      }

      createRequest(requestList: card[]) : Observable<any> {
        
        return this.http.post<request>(this.url + "Trades/Requests/Add/" + this.userId, requestList, this.httpOptions);
      }

      getReqByTradeId(tradeId: number) : Observable<card[]>{
       return this.http.get<card[]>(this.url +"Trades/Requests/" + tradeId);
      }
    
      
}