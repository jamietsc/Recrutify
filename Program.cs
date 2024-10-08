using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Recrutify.Data;
using Recrutify.DataAccessLayer.Data;
using Recrutify.DataAccessLayer.Repositories;
using Recrutify.DataAccessLayer.SqlDataAccess;
using Recrutify.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<HelperModel>();
//builder.Services.AddSingleton<WeatherForecastService>();

//Repositories


//Data
builder.Services.AddScoped<IBewerber<BewerberModel>, BewerberData>();
builder.Services.AddScoped<IMultipleChoice<MultipleChoiceModel>, MultipleChoiceData>();

//SqlAccess
builder.Services.AddScoped<ISqlDataAccess, SqlDataAccess>();

//Models
builder.Services.AddScoped<BewerberModel>();
builder.Services.AddScoped<MultipleChoiceModel>();
builder.Services.AddScoped<BewerberTestModel>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
