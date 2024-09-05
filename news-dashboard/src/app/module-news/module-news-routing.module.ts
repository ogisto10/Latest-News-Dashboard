import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './header/header.component';
import { NewsComponent } from './news/news.component';

const routes: Routes = [
  {path: '',
    component: HomeComponent,
    children: [
      { path: 'header', component: HeaderComponent },
      { path: 'news', component: NewsComponent }
    ]}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ModuleNewsRoutingModule { }
