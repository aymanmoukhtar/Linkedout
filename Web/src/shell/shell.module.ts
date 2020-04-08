import { NgModule } from '@angular/core';

import { ShellRoutingModule } from './shell-routing.module';
import { ShellComponent } from './shell.component';

import { SharedModule } from '../shared/shared.module';
import { CoreModule } from '../core/core.module';
import { HeaderComponent } from './components/header/header.component';

@NgModule({
  declarations: [
    ShellComponent,
    HeaderComponent
  ],
  imports: [
    SharedModule,
    CoreModule,
    ShellRoutingModule,
  ],
  providers: [],
  bootstrap: [ShellComponent]
})
export class ShellModule { }
