using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyStore.Data;
using MyStore.Models;
using MyStore.Options;
using MyStore.Repository;
using MyStore.Services;
using StartASP.Repositories;

namespace MyStore
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            var connStrSQL = builder.Configuration.GetConnectionString("LocalSQL");

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connStrSQL));

            //builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>();
            builder.Services.AddScoped<ProductRepository>();
            builder.Services.AddScoped<CategoryRepository>();
            builder.Services.AddScoped<IUploudService, UploudImageService>();

            builder.Services.Configure<SmtpOptions>(builder.Configuration.GetSection("SMTP"));
            builder.Services.AddTransient<IEmailSender, EmailSender>();


            //Serialize and deserialize Step one in authentication
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => { options.LoginPath = "/"; });

            // adding identity
            builder.Services.AddDefaultIdentity<AppUser>(options => { 
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = true;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

            builder.Services.AddAuthorization(options => {
                options.AddPolicy("Edit", p =>
                                          p.RequireAssertion(context => context.User.IsInRole("Admin")
                                          || context.User.HasClaim("CanEditOrDelete", "true")
                                          ));
                options.AddPolicy("OnlyAdmin", p =>
                                               p.RequireRole("Admin"));
                options.AddPolicy("Client", p =>
                                            p.RequireAuthenticatedUser());
            });

            //convenint way : to configure authorizetion pages form program file
            builder.Services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeAreaFolder("Identity", "/Identity/Account/Manage");
                options.Conventions.AuthorizeFolder("/Categories", "OnlyAdmin");
                options.Conventions.AuthorizeFolder("/Users", "OnlyAdmin");

                options.Conventions.AuthorizePage("/Products/Create", "Edit");
                options.Conventions.AuthorizePage("/Products/Edit", "Edit");
                options.Conventions.AuthorizePage("/Products/Details", "Edit");
                options.Conventions.AuthorizePage("/Products/Delete", "Edit");
                options.Conventions.AuthorizePage("/Products/index", "Client");


            });

            var app = builder.Build();


            // seed roles to the database ,we need to create a scope to get the service of role manager 
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                await DbInitializer.SeedRoles(roleManager);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseMigrationsEndPoint();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
