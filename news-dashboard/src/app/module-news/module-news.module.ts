import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModuleNewsRoutingModule } from './module-news-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { NewsComponent } from './news/news.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { HttpClient, HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    NewsComponent,
    HeaderComponent,
    HomeComponent
  ],
  imports: [
    CommonModule,
    ModuleNewsRoutingModule,
    ReactiveFormsModule,
    RouterModule,
    HttpClientModule

  ]
})
export class ModuleNewsModule { }
