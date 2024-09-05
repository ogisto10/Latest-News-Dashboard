import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ModuleNewsRoutingModule } from './module-news-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { NewsComponent } from './news/news.component';


@NgModule({
  declarations: [
    NewsComponent
  ],
  imports: [
    CommonModule,
    ModuleNewsRoutingModule,
    ReactiveFormsModule,
  ]
})
export class ModuleNewsModule { }
