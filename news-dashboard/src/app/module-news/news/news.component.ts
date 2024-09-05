import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NewsService } from '../../Service/news-service.service';

@Component({
  selector: 'app-news',
  standalone: true,
  imports: [],
  templateUrl: './news.component.html',
  styleUrl: './news.component.css'
})
export class NewsComponent {
  newsResponse: any;
  sources: any[] = [];
  searchForm!: FormGroup;
  pageNumber = 1;
  pageSize = 50;

  constructor(private newsService: NewsService, private fb: FormBuilder) {}

  ngOnInit(): void {
    this.loadNews();
    this.newsService.getAllSources().subscribe(sources => this.sources = sources);

    this.searchForm = this.fb.group({
      searchQuery: [''],
      sourceName: ['']
    });
  }

  loadNews() {
    this.newsService.getPagedArticles(this.pageNumber, this.pageSize)
      .subscribe(response => this.newsResponse = response);
  }

  searchArticles() {
    const { searchQuery } = this.searchForm.value;
    this.newsService.searchArticles(this.pageNumber, this.pageSize, searchQuery)
      .subscribe(response => this.newsResponse = response);
  }

  filterArticles() {
    const { sourceName } = this.searchForm.value;
    this.newsService.filterArticles(this.pageNumber, this.pageSize, sourceName)
      .subscribe(response => this.newsResponse = response);
  }

  onPageChange(newPage: number) {
    this.pageNumber = newPage;
    this.loadNews();
  }
}


