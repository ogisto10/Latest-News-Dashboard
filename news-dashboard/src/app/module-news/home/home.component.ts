import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
 styleUrls: ['./home.component.css']
})
export class HomeComponent {
  searchQuery: string = '';
  selectedSource: string='';

  onSearch(query: string): void {
    this.searchQuery = query;
  }
  onfilter(sourceName: string):void{
    this.selectedSource =sourceName;
  }

}
