using GoogleBooksMVC.Services;
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<GoogleBooksService>(client =>
{
    client.BaseAddress = new Uri("https://www.googleapis.com/books/v1/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});


builder.Services.AddDataProtection()
    .SetApplicationName("GoogleBooksMVC")
    .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(AppContext.BaseDirectory, "keys")));

builder.WebHost.UseUrls("http://*:80");

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

Console.WriteLine("Applicazione avviata. Premi CTRL+C per terminare.");
await app.RunAsync();
