using CommentProject.BusinessLayer.Abstract;
using CommentProject.BusinessLayer.Concrete;
using CommentProject.DataAccessLayer.Abstract;
using CommentProject.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICommentDal, EfCommentDal>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<ITitleDal, EfTitleDal>();
builder.Services.AddScoped<ITitleService, TitleManager>();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
