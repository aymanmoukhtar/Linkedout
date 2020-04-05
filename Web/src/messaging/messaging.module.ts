import { NgModule } from '@angular/core';

import { MessagingRoutingModule } from './messaging-routing.module';
import { MessagingComponent } from './pages/messaging.component';

@NgModule({
  declarations: [
    MessagingComponent
  ],
  imports: [
    MessagingRoutingModule
  ]
})
export class MessagingModule { }