import { Routes } from '@angular/router';


export const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./module-news/module-news.module').then(m => m.ModuleNewsModule)
  }

];
