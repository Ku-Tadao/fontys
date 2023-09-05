using RedditBusinessLayer.Entities;
using RedditBusinessLayer.Interfaces;
using RedditBusinessLayer.Services;
using RedditDataLayer.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// A scoped service is a service for which a new instance is created once per client request (connection)
// When you register the a Repo class as a service using the AddScoped method,
// the service container will automatically resolve the connectionString parameter and pass it to the constructor when creating an instance of the Repo class.

// Register a service of type IPostRepository with an implementation of type PostRepository
builder.Services.AddScoped<IPostRepository, PostRepository>();

// Register a service of type ISubredditRepository with an implementation of type SubredditRepository
builder.Services.AddScoped<ISubredditRepository, SubredditRepository>();

// Register a service of type IUserRepository with an implementation of type UserRepository
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Singleton = everyone makes use of a single instance (transient is better, but i don't understand it)
builder.Services.AddSingleton(builder.Configuration.GetConnectionString("DefaultConnection"));


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
