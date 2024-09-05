import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NewsService {
  private apiUrl = 'https://localhost:7006/api/News';

  constructor(private http: HttpClient) { }

  getPagedArticles(pageNumber: number = 1, pageSize: number = 50): Observable<any> {
    let params = new HttpParams()
      .set('pageNumber', pageNumber.toString())
      .set('pageSize', pageSize.toString());

    return this.http.get<any>(`${this.apiUrl}/paged-articles`, { params });
  }

  searchArticles(pageNumber: number = 1, pageSize: number = 50, searchQuery?: string): Observable<any> {
    let params = new HttpParams()
      .set('pageNumber', pageNumber.toString())
      .set('pageSize', pageSize.toString())
      .set('searchQuery', searchQuery || '');

    return this.http.get<any>(`${this.apiUrl}/search-articles`, { params });
  }

  filterArticles(pageNumber: number = 1, pageSize: number = 50, sourceName?: string): Observable<any> {
    let params = new HttpParams()
      .set('pageNumber', pageNumber.toString())
      .set('pageSize', pageSize.toString())
      .set('sourceName', sourceName || '');

    return this.http.get<any>(`${this.apiUrl}/filter-articles`, { params });
  }

  getAllSources(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/sources`);
  }
}
