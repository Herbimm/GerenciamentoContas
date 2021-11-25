using GerenciamentoContas.Domain.Entity;
using GerenciamentoContas.Domain.Entity.Identity;
using GerenciamentoContas.Domain.Entity.Identy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
c.SwaggerDoc("v1", new OpenApiInfo { Title = "Empresa X", Version = "v1," }));
builder.Services.AddIdentityCore<IdentityUser>(options => { });
builder.Services.AddScoped<IUserStore<IdentityUser>, UserOnlyStore<IdentityUser ,IdentityDbContext>>();
builder.Services.AddAuthentication("cookies").AddCookie("cookies", options => options.LoginPath = "/Home/Login");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthentication();
app.UseSwagger();
app.UseSwaggerUI(c =>
{

    c.RoutePrefix = string.Empty;
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
