import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './modules/material.module';
import { GraphQLModule } from 'src/graphql/graphql.module';
import { FormsModule } from '@angular/forms';


@NgModule({
  imports: [
    MaterialModule,
    GraphQLModule,
    FormsModule
  ],
  exports: [
    MaterialModule,
    CommonModule,
    GraphQLModule,
    FormsModule
  ]
})
export class SharedModule { }