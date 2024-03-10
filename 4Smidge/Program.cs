using Smidge;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSmidge(builder.Configuration.GetSection("smidge"));


builder.Services.AddControllersWithViews();
// Add services to the container.

var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSmidge(bundle =>
{
    bundle.CreateJs("my-js-bundle","~/js/site.js", "~/js/site2.js");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
