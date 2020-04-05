import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'feed', loadChildren: () => import('./../feed/feed.module').then(({ FeedModule }) => FeedModule) },
  { path: 'messaging', loadChildren: () => import('./../messaging/messaging.module').then(({ MessagingModule }) => MessagingModule) },
  { path: 'identity', loadChildren: () => import('./../identity/identity.module').then(({ IdentityModule }) => IdentityModule) },
  { path: '', redirectTo: 'feed', pathMatch: 'full' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class ShellRoutingModule { }
