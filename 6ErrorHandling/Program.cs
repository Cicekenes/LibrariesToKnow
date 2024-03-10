using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //Developer'in görmesi gereken hatalarýn olduðu sayfadýr.
    //app.UseDeveloperExceptionPage();

    //app.UseStatusCodePages(MediaTypeNames.Text.Plain, "Bir hata var durum kodu:{0}"); //Durum kodlarýný dönmektedir.


    app.UseStatusCodePages(async context =>
    { //hata sayfasýný özelleþtirebiliyoruz.
        context.HttpContext.Response.ContentType = MediaTypeNames.Text.Html;
        await context.HttpContext.Response.WriteAsync($"<b>Bir hata var. Durum kodu</b> : {context.HttpContext.Response.StatusCode}");
    });
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//Uygulamada bir hata alýndýðýnda bir hata sayfasýna yönlendirir.
//app.UseExceptionHandler("/Home/Error");


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
