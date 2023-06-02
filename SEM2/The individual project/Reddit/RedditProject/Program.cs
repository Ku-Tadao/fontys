using RedditBusinessLayer.Interfaces;
using RedditBusinessLayer.Services;
using RedditDataLayer;
using RedditDataLayer.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped(x => new DatabaseHelper(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException()));
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ISubredditService, SubredditService>();
builder.Services.AddScoped<IUserService, UserService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
