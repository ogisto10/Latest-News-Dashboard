using Latest_News_Dashboard.DailyBackgroundService;
using Latest_News_Dashboard.Model;
using Latest_News_Dashboard.Options;
using Latest_News_Dashboard.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<NewsDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddOptions<NewsApiOptions>().BindConfiguration("NewsApi");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddScoped<INewsAPIService, NewsAPIService>();
builder.Services.AddScoped<IMyNewsService, MyNewsService>();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Latest News API", Version = "v1" });
});
builder.Services.AddHostedService<DailyUpdateService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Latest News API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseCors("AllowAngularApp");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
