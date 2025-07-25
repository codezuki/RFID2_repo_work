using Microsoft.EntityFrameworkCore;
using RFID2.Pages.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DbConnection.Init(builder.Configuration);
builder.Services.AddRazorPages();
//EfCore 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GIC_Local_DB")));

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
