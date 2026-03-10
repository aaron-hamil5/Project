var builder = WebApplication.CreateBuilder(args);
//Adding Razor's services to the builder
builder.Services.AddRazorPages();
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapRazorPages();

app.Run();