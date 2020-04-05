import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './modules/material.module';

@NgModule({
  imports: [MaterialModule],
  exports: [
    MaterialModule, CommonModule
  ]
})
export class SharedModule { }