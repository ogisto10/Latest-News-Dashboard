﻿using Latest_News_Dashboard.Dto;
using Latest_News_Dashboard.Model;
using Microsoft.EntityFrameworkCore;
using NewsAPI.Models;

namespace Latest_News_Dashboard.Service
{
    public class MyNewsService:IMyNewsService
    {
        private readonly NewsDbContext _context;

        public MyNewsService(NewsDbContext context )
        {
            _context = context;
        }
        // Method to get paginated articles from the database
        public async Task<NewsResponseDTO> GetPagedArticlesAsync(int pageNumber, int pageSize)
        {
            var totalArticles = await _context.Articles.CountAsync();
            var articles = await _context.Articles
                                         .Skip((pageNumber - 1) * pageSize) 
                                         .Take(pageSize)  
                                         .Select(article => new ArticleDto(article)) 
                                         .ToListAsync();
            return new NewsResponseDTO
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Total = totalArticles,
                Articles = articles
            };
        }
        // Method to search for articles by a query with pagination support
        public async Task<NewsResponseDTO> SearchArticlesAsync(int pageNumber, int pageSize, string? searchQuery = null)
        {
            
            var query = _context.Articles.AsQueryable();
            // If a search query is provided, filter articles by (title,author,description,or content)
            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(article =>
                    article.Title.Contains(searchQuery) ||
                    article.Author.Contains(searchQuery) ||
                    article.Description.Contains(searchQuery) ||
                    article.Content.Contains(searchQuery)
                );
            }

            
            var totalArticles = await query.CountAsync();

            
            var articles = await query
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .Select(article => new ArticleDto(article))
                                .ToListAsync();

            
            return new NewsResponseDTO
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Total = totalArticles,
                Articles = articles
            };
        }
        // Method to filter articles by source name with pagination support
        public async Task<NewsResponseDTO> FilterArticlesAsync(int pageNumber, int pageSize, string? sourceName = null)
        {
            var query = _context.Articles.AsQueryable();
            if (!string.IsNullOrEmpty(sourceName))
            {
                query = query.Where(article => article.Source.Name == sourceName);

            }
            var totalArticles = await query.CountAsync();


            var articles = await query
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .Select(article => new ArticleDto(article))
                                .ToListAsync();
            return new NewsResponseDTO
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Total = totalArticles,
                Articles = articles
            };

        }
        // Method to get all unique news sources from the database
        public async Task<List<Source>> GetAllSourcesAsync()
        {
            //To be cached for performance sake and to lighten the database load
            var sources = await _context.Sources 
                                .ToListAsync();
            return sources;
        }
    }
}
