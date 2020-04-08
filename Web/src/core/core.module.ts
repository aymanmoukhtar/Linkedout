import { HttpClientModule } from '@angular/common/http';
import { NgModule, Optional, SkipSelf } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AuthGuard } from './guards/auth.guard';
import { EnsureModuleLoadedOnceGuard } from './guards/import.guard';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
    exports: [BrowserAnimationsModule, HttpClientModule, FormsModule, BrowserModule],
    providers: [AuthGuard]
})
export class CoreModule extends EnsureModuleLoadedOnceGuard {
    // This is to prevent core module from being imported more than once
    // as it only contains singleton services that once imported into ShellModule will be shared accross the app
    // @SkipSelf: skip the current injector and look for the dependency in the parent injector
    // @Optional: parentModule can be undefined, ideally it should
    constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
        super(parentModule);
    }
}