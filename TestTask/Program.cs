using APIConfiguration.Configuration.Swagger;
using Application.Configuration;
using DAL.Configuration;

var builder = WebApplication.CreateBuilder (args);

// Add services to the container.
builder.Services.AddRazorPages ();
builder.Services.AddControllers ();
builder.Services.AddSwaggerConfig (builder.Configuration);
builder.Services.AddApplicationConfiguration (builder.Configuration);
builder.Services.AddDalConfiguration (builder.Configuration);


var app = builder.Build ();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment ())
{
    app.UseExceptionHandler ("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts ();
}
app.UseHttpsRedirection ();
app.UseStaticFiles ();

app.UseRouting ();

app.UseAuthorization ();

app.MapRazorPages ();
app.MapControllers ();
app.UseSwaggerImpl ();

app.Run ();
