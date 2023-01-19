using GuardEmpSignin.Models;
using GuardEmpSignin.Repository.Employee;
using GuardEmpSignin.Repository.Guard;
using GuardEmpSignin.Services.Employee;
using GuardEmpSignin.Services.Guard;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContextPool<GuardDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("NewConnection")));

builder.Services.AddScoped<IEmployeeDBrep,EmployeeDBrep>();
builder.Services.AddScoped<IGuardDBrep, GuardDBrep>();
builder.Services.AddScoped<IEService,EService>();
builder.Services.AddScoped<IGService, GService>();


builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<GuardDbContext>();





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
