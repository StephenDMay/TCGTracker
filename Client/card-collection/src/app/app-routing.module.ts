import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './account/login.component';
import { AddTradeComponent } from './add-trade/add-trade.component';
import { CardDetailComponent } from './card-detail/card-detail.component';
import { CardListComponent } from './card-list/card-list.component';
import { CollectionAllComponent } from './collection-all/collection-all.component';
import { CollectionByRarityComponent } from './collection-by-rarity/collection-by-rarity.component';
import { CollectionBySeriesComponent } from './collection-by-series/collection-by-series.component';
import { CollectionBySuperComponent } from './collection-by-super/collection-by-super.component';
import { CollectionByTypeComponent } from './collection-by-type/collection-by-type.component';
import { CollectionListComponent } from './collection-list/collection-list.component';
import { CollectionViewComponent } from './collection-view/collection-view.component';
import { HomeComponent } from './home/home.component';
import { SeriesListComponent } from './series-list/series-list.component';
import { SetTrackerComponent } from './set-tracker/set-tracker.component';
import { TradeBoardComponent } from './trade-board/trade-board.component';
import { TradeDetailComponent } from './trade-detail/trade-detail.component';
import { TradeRequestComponent } from './trade-request/trade-request.component';

const accountModule = () => import('./account/account.module').then(x => x.AccountModule);


const routes: Routes = [{path: "cardDetails/:id", component: CardDetailComponent},
{path: "set/:id", component: CardListComponent},
{path: "allSets", component: SeriesListComponent},
{path: "account", loadChildren: accountModule},
{path: "collection", component: CollectionViewComponent},
{path: "collection/myCards", component: CollectionAllComponent},
{path: "trades", component: TradeBoardComponent},
{path: "collection/:type", component: CollectionByTypeComponent},
{path: "collection/super/:super", component: CollectionBySuperComponent},
{path: "collection/rarity/:rarity", component: CollectionByRarityComponent},
{path: "collection/series/:series", component: CollectionBySeriesComponent},
{path: "trade/:tradeId", component: TradeDetailComponent},
{path: "", component: HomeComponent},
{path: "trade/request/:cardId", component: TradeRequestComponent}]



@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}