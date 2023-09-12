using App.Domain.Core.BaseData.Contract.Repositories;
using App.Domain.Core.BaseData.Contract.Services;
using App.Domain.Core.Customer.Contract.Repositories;
using App.Domain.Core.Customer.Contract.Services;
using App.Domain.Core.Seller.Cantract.Repositories;
using App.Domain.Core.Seller.Cantract.Services;
using App.Domain.Core.Shop.Contract.Repositories;
using App.Domain.Core.Shop.Contract.Services;
using App.Domain.Services.BaseData;
using App.Domain.Services.Customer;
using App.Domain.Services.Seller;
using App.Domain.Services.Shop;
using App.Infrastructure.Repositories.Ef.BaseData;
using App.Infrastructure.Repositories.Ef.Customer;
using App.Infrastructure.Repositories.Ef.Seller;
using App.Infrastructure.Repositories.Ef.Shop;
using App.Infrastructure.SqlServers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace App.EndPoint.Mvc.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(option =>
           option.UseSqlServer(builder.Configuration.GetConnectionString("MainConnection")));
            var app = builder.Build();

            builder.Services.AddScoped<IAddressCommandRepository,AddressCommandRepository>();
            builder.Services.AddScoped<IAddressQueryRepository, AddressQueryRepository>();
            builder.Services.AddScoped<IAddressService,AddressService>();

            builder.Services.AddScoped<ICommentCommandRepository, CommentCommandRepository>();
            builder.Services.AddScoped<ICommentQueryRepository, CommentQuerydRepository>();
            builder.Services.AddScoped<ICommentService, CommentService>();

            builder.Services.AddScoped<ISuggestionCommandRepository, SuggestionCommandRepository>();
            builder.Services.AddScoped<ISuggestionQueryRepository, SuggestionQueryRepository>();
            builder.Services.AddScoped<ISuggestionService, SuggestionService>();

            builder.Services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
            builder.Services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            builder.Services.AddScoped<ISellerCommandRepository, SellerCommandRepository>();
            builder.Services.AddScoped<ISellerQueryRepository, SellerQueryRepository>();
            builder.Services.AddScoped<ISellerService, SellerService>();

            builder.Services.AddScoped<ICityCommandRepository, CityCommandRepository>();
            builder.Services.AddScoped<ICityQueryRepository, CityQueryRepository>();
            builder.Services.AddScoped<ICityService, CityService>();

            builder.Services.AddScoped<IProvinceCommandRepository, ProvinceCommandRepository>();
            builder.Services.AddScoped<IProvinceQueryRepository, ProvinceQueryRepository>();
            builder.Services.AddScoped<IProvinceService, ProvinceService>();

            builder.Services.AddScoped<ISiteCommandRepository, SiteCommandRepository>();
            builder.Services.AddScoped<ISiteQueryRepository, SiteQueryRepository>();
            builder.Services.AddScoped<ISiteService, SiteService>();

            builder.Services.AddScoped<IBidCommandRepository, BidCommandRepository>();
            builder.Services.AddScoped<IBidQueryRepository, BidQueryRepository>();
            builder.Services.AddScoped<IBidService, BidService>();

            builder.Services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
            builder.Services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddScoped<IFactorCommandRepository, FactorCommandRepository>();
            builder.Services.AddScoped<IFactorQueryRepository, FactorQueryRepository>();
            builder.Services.AddScoped<IFactorService, FactorService>();

            builder.Services.AddScoped<IPictureCommandRepository, PictureCommandRepository>();
            builder.Services.AddScoped<IPictureQueryRepository, PictureQueryRepository>();
            builder.Services.AddScoped<IPictureService, PictureService>();

            builder.Services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            builder.Services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddScoped<IProductDetailCommandRepository, ProductDetailCommandRepository>();
            builder.Services.AddScoped<IProductDetailQueryRepository, ProductDetailQueryRepository>();
            builder.Services.AddScoped<IProductDetailService, ProductDetailService>();

            builder.Services.AddScoped<IShopCommandRepository, ShopCommandRepository>();
            builder.Services.AddScoped<IShopQueryRepository, ShopQueryRepository>();
            builder.Services.AddScoped<IShopService, ShopService>();


            builder.Services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>(
        options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;

            //options.User.AllowedUserNameCharacters
            //options.User.RequireUniqueEmail

            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 3;
            options.Password.RequiredUniqueChars = 1;

        });
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
        }
    }
}