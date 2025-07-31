using MemoriaLitteraria.Repositories;
using MemoriaLitteraria.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new MongoClient(connectionString);
});

builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var databaseName = builder.Configuration["Database"]; 
    return client.GetDatabase(databaseName);
});

builder.Services.AddScoped<FileRepository>();
builder.Services.AddScoped<FileService>();
builder.Services.AddScoped<AuthorRepository>();
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<SectionService>();
builder.Services.AddScoped<SectionRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
