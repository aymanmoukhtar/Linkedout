import { NgModule } from '@angular/core';

import { IdentityRoutingModule } from './identity-routing.module';
import { LoginComponent } from './pages/login/login.component';
import { SharedModule } from 'src/shared/shared.module';
import { RegisterComponent } from './pages/register/register.component';

import { LoginMutation } from './mutations/login.mutation';
import { IdentityService } from './services/identity.service';
@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    IdentityRoutingModule,
    SharedModule,

  ],
  providers: [
    LoginMutation,
    IdentityService
  ]
})
export class IdentityModule { }