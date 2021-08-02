import { card } from "./card";
import { trade } from "./trade";

export interface request {
    id: number,
    Trade: trade,
    RequestedCards: card[]
}