using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Netflix.Business.Abstract;
using Netflix.Business.Concrete;
using Netflix.DataAccess;
using Netflix.DataAccess.Abstract;
using Netflix.DataAccess.Concrete;

namespace Netflix.Business.DependencyResolvers.Microsoft
{
    public static class NetFlixBusinessDependencies
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NetflixDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("NetflixDb"));
            });

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMovieService, MovieManager>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IMovieCategoryService, MovieCategoryManager>();
            services.AddScoped<IMovieCategoryRepository, MovieCategoryRepository>();
            services.AddScoped<IJwtService, JwtManager>();
        }
    }


}
