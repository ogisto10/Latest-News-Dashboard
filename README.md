![Screenshot_6-9-2024_183415_localhost](https://github.com/user-attachments/assets/280eb2ea-becc-4004-8166-920dd1c42890)
![Screenshot_6-9-2024_183431_localhost](https://github.com/user-attachments/assets/6a96a780-4340-4eda-a93e-cecc3390be58)
![Screenshot_6-9-2024_183457_localhost](https://github.com/user-attachments/assets/98858bf2-5dbd-4969-b52f-e822123f1c12)
![Screenshot_6-9-2024_183514_localhost](https://github.com/user-attachments/assets/d3e4d49c-a339-4214-bada-892234449547)
![Screenshot_6-9-2024_153746_localhost](https://github.com/user-attachments/assets/e2c7009c-2f21-494e-afb5-ed756a32cf24)
# Latest News Dashboard

## Overview
The **Latest News Dashboard** is a full-stack application that combines `.NET 8` for the backend and `Angular 18` for the frontend. It provides functionalities to fetch, display, and manage news articles with features such as pagination, search, and filtering. The application includes a background service to update news articles daily.

## Project Setup

### Backend Setup

#### Requirements
- .NET 8 SDK
- SQL Server
- NewsAPI Account (for API key)
- Entity Framework Core
- In-Memory Caching

#### Steps to Set Up

1. **Clone the Repository**
    ```bash
    git clone https://github.com/ogisto10/Latest-News-Dashboard.git
    cd latest-news-dashboard
    ```

2. **Update Configuration**
   Edit the `appsettings.json` file to include your SQL Server connection string and NewsAPI key.
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "server=YOUR_SQL_SERVER; Database=LatestNewsDB; Trusted_Connection=True; TrustServerCertificate=True;"
      },
      "NewsApi": {
        "ApiKey":"YOUR_NEWS_API_KEY"
      }
    }
    ```

3. **Set Up the Database**
    - Apply migrations to set up the database schema:
      ```bash
      dotnet ef migrations add InitialCreate
      dotnet ef database update
      ```

4. **Run the Backend**
    - Navigate to the backend project folder and start the application:
      ```bash
      dotnet run
      ```

    - The API will be accessible at:  
      `https://localhost:7006/`

#### Backend Features
- **Endpoints**:
  - `/api/News/paged-articles`: Get paginated articles.
  - `/api/News/search-articles`: Search articles by query.
  - `/api/News/filter-articles`: Filter articles by source.
  - `/api/News/sources`: Get all sources.

- **Background Service**:
    The `DailyUpdateService` updates news articles every 24 hours, configured as a hosted service.

- **Database Indexing**:
    Indexing is configured for the `Author` field in the `KeyedArticle` table to optimize queries:
    ```csharp
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KeyedArticle>()
            .HasIndex(a => a.Author)
            .HasDatabaseName("IX_Author");

        base.OnModelCreating(modelBuilder);
    }
    ```

### Frontend Setup

#### Requirements
- Node.js (LTS version)
- Angular CLI

#### Steps to Set Up

1. **Install Dependencies**
    ```bash
    npm install
    ```

2. **Run the Frontend**
    ```bash
    ng serve
    ```

3. **Access the Application**
   Open your browser and navigate to:  
   `http://localhost:4200`

#### Frontend Features
- **Home Page**: Displays articles with pagination, search, and filtering functionalities.
- **Header Component**: Contains search and filter controls.
- **News Component**: Displays articles in a grid format with pagination controls.
- **Styling**: Uses Tailwind CSS for responsive and modern UI design.

## Database Setup

The application uses SQL Server for data storage. The schema includes:
- **Articles**: Stores news articles with a unique ID.
- **Sources**: Stores news sources.

### Database Configuration
Ensure the `DefaultConnection` string in `appsettings.json` points to your SQL Server instance.

### Entity Framework Core
To manage the database schema:
  ```bash
  dotnet ef migrations add <MigrationName>
  dotnet ef database update
  ```

## Caching Setup

The project uses **In-Memory Caching** to cache news sources and reduce API call frequency.

### Configuring Caching
In `Program.cs`, caching is enabled using:
```csharp
builder.Services.AddMemoryCache();
```
The `SourceCacheService` handles caching of news sources.

## API Documentation

### Endpoints

1. **GET** `/api/News/paged-articles`
    - Parameters: `pageNumber` (default: 1), `pageSize` (default: 50)
    - Description: Fetches paginated news articles.

2. **GET** `/api/News/search-articles`
    - Parameters: `searchQuery`, `pageNumber` (default: 1), `pageSize` (default: 50)
    - Description: Searches for articles based on the query.

3. **GET** `/api/News/filter-articles`
    - Parameters: `sourceName`, `pageNumber` (default: 1), `pageSize` (default: 50)
    - Description: Fetches articles filtered by source.

4. **GET** `/api/News/sources`
    - Description: Fetches all available news sources.

## Running the Project

1. Ensure both backend and frontend are running:
   - **Backend**: `dotnet run`
   - **Frontend**: `ng serve`

2. Open the browser and navigate to `http://localhost:4200`.

## Additional Information

- **Background Service**: `DailyUpdateService` updates news daily.
- **Swagger**: Explore the API at `https://localhost:7006/swagger`.
