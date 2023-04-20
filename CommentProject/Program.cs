using CommentProject.BusinessLayer.Abstract;
using CommentProject.BusinessLayer.Concrete;
using CommentProject.DataAccessLayer.Abstract;
using CommentProject.DataAccessLayer.Concrete;
using CommentProject.DataAccessLayer.EntityFramework;
using CommentProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);


builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);

builder.Host.UseNLog();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICommentDal, EfCommentDal>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<ITitleDal, EfTitleDal>();
builder.Services.AddScoped<ITitleService, TitleManager>();

builder.Services.AddScoped<ICommentDal, EfCommentDal>();
builder.Services.AddScoped<ICommentService, CommentManager>();

builder.Services.AddDbContext<Context>();


builder.Services.AddIdentity<AppUser, AppRole>(options =>
{

    options.Password.RequiredLength = 10;
    options.Password.RequiredUniqueChars = 3;

    options.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<Context>()
  .AddDefaultTokenProviders();








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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();