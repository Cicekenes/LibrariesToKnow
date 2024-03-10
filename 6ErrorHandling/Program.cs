using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //Developer'in g�rmesi gereken hatalar�n oldu�u sayfad�r.
    //app.UseDeveloperExceptionPage();

    //app.UseStatusCodePages(MediaTypeNames.Text.Plain, "Bir hata var durum kodu:{0}"); //Durum kodlar�n� d�nmektedir.


    app.UseStatusCodePages(async context =>
    { //hata sayfas�n� �zelle�tirebiliyoruz.
        context.HttpContext.Response.ContentType = MediaTypeNames.Text.Html;
        await context.HttpContext.Response.WriteAsync($"<b>Bir hata var. Durum kodu</b> : {context.HttpContext.Response.StatusCode}");
    });
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//Uygulamada bir hata al�nd���nda bir hata sayfas�na y�nlendirir.
//app.UseExceptionHandler("/Home/Error");


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
