import { NgModule } from '@angular/core';

import { FeedRoutingModule } from './feed-routing.module';
import { FeedComponent } from './pages/feed.component';

@NgModule({
  declarations: [
    FeedComponent
  ],
  imports: [
    FeedRoutingModule
  ]
})
export class FeedModule { }