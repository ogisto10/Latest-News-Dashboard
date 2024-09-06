import { Component, Input, OnInit, OnChanges } from '@angular/core';
import { NewsService } from '../../Service/news-service.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit, OnChanges {
  @Input() searchQuery: string = '';
  @Input() selectedSource: string = '';

  newsResponse: any;
  pageNumber = 1;
  pageSize = 50;

  constructor(private newsService: NewsService) {}

  ngOnInit(): void {
    this.loadNews();
  }

  ngOnChanges(): void {
    this.pageNumber = 1;
    this.loadNews();
  }

  loadNews(): void {
    if (this.searchQuery) {
      this.loadSearchResults();
    } else if (this.selectedSource) {
      this.loadFilterResults();
    } else {
      this.loadPagedArticles();
    }
  }

  loadPagedArticles(): void {
    this.newsService.getPagedArticles(this.pageNumber, this.pageSize)
      .subscribe(response => this.newsResponse = response);
  }

  loadSearchResults(): void {
    this.newsService.searchArticles(this.pageNumber, this.pageSize, this.searchQuery)
      .subscribe(response => this.newsResponse = response);
  }

  loadFilterResults(): void {
    this.newsService.filterArticles(this.pageNumber, this.pageSize, this.selectedSource)
      .subscribe(response => this.newsResponse = response);
  }

  nextPage(): void {
    this.pageNumber += 1;
    this.loadNews();
  }

  previousPage(): void {
    if (this.pageNumber > 1) {
      this.pageNumber -= 1;
      this.loadNews();
    }
  }
}
