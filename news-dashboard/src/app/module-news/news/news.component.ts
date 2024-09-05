import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { NewsService } from '../../Service/news-service.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit {

  newsResponse: any;
  pageNumber = 2;
  pageSize = 50;
  searchQuery = '';
  selectedSource = '';

  constructor(private newsService: NewsService) {}

  ngOnInit(): void {
    this.loadNews();
  }

  loadNews() {
    this.newsService.getPagedArticles(this.pageNumber, this.pageSize)
      .subscribe(response => this.newsResponse = response);
  }

  onSearch(searchQuery: string) {
    this.searchQuery = searchQuery;
    this.pageNumber = 1;
    this.loadNews();
  }

  onFilter(sourceName: string) {
    this.selectedSource = sourceName;
    this.pageNumber = 1;
    this.loadNews();
  }


}
