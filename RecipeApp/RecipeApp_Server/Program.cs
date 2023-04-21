using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RecipeApp_Server.Data;
using RecipeApp_DataAccess;
using Microsoft.EntityFrameworkCore;
using RecipeApp_DataAccess.Folder;
using RecipeApp_Business.Repository.IRepository;
using RecipeApp_Business.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<ApplicationDBContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRecipeTypeRepository, RecipeTypeRepository>(); //create service service when requested
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());   //loads auto mapper dependecy injection
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();}

else
{
    //shows the eror in the developer exception page instead
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
