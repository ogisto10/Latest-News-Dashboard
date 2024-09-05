import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NewsService } from '../../Service/news-service.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent  implements OnInit {
  @Output() search = new EventEmitter<string>();
  @Output() filter = new EventEmitter<string>();

  searchForm: FormGroup;
  sources: any[] = [];

  constructor(private fb: FormBuilder, private newsService: NewsService) {
    this.searchForm = this.fb.group({
      searchQuery: [''],
      sourceName: ['']
    });
  }

  ngOnInit(): void {
    this.newsService.getAllSources().subscribe(sources => {
      this.sources = sources;
    });
  }




}
