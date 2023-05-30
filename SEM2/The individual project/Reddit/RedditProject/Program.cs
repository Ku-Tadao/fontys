using RedditBusinessLayer.Interfaces;
using RedditBusinessLayer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IPostService>(x => new PostService(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ISubredditService>(x => new SubredditService(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserService>(x => new UserService(builder.Configuration.GetConnectionString("DefaultConnection")));


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
