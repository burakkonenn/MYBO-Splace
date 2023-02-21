using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Web.Persistence.Contexts;
using System.Threading.Tasks;
using Web.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Web.Application.Abstractions.Services.User;
using Web.Persistence.Services.User;
using FluentValidation;
using FluentValidation.AspNetCore;
using Web.Application.DTOs.User;
using Web.Application.Validators.Users;
using Web.Application.Validators.DesignBackground;
using Web.Application.DTOs.Design.DesignBackground;
using Web.Application.Abstractions.Services.Design;
using Web.Persistence.Services.Design;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using Web.Application.DTOs.Design.DesignButton;
using Web.Application.Validators.DesignButton;
using Web.Application.DTOs.Design.DesignFont;
using Web.Application.Validators.DesignFont;
using Web.Application.DTOs.Language;
using Web.Application.Validators.Language;
using Web.Application.Abstractions.Services.Language;
using Web.Persistence.Services.Language;
using Web.Application.DTOs.Words;
using Web.Application.Validators.Word;
using Web.Application.Abstractions.Services.Words;
using Web.Persistence.Services.Words;
using Web.Application.Abstractions.Services.SocialMedia;
using Web.Persistence.Services.SocialMedia;
using Web.Application.DTOs.SocialMedia;
using Web.Application.Validators.SocialMedia;
using Web.Application.Abstractions.Services.Link;
using Web.Persistence.Services.Link;
using Web.Application.DTOs.Link;
using Web.Application.Validators.Link;

namespace Web.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SplaceDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MsSqlConnectionString")));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<SplaceDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IDesignBackgroundService,DesignBackgroundService>();
            services.AddScoped<IDesignButtonService,DesignButtonService>();
            services.AddScoped<IDesignFontService,DesignFontService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IWordsService, WordsService>();
            services.AddScoped<ISocialMediaService, SocialMediaService>();
            services.AddScoped<ILinkService, LinkService>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddFluentValidationAutoValidation();
            services.AddScoped<IValidator<CreateUser>, CreateUserValidator>();
            services.AddScoped<IValidator<UpdateUser>, UpdateUserValidator>();

            services.AddScoped<IValidator<CreateDesignBackground>, CreateDesignBackgroundValidator>();
            services.AddScoped<IValidator<PostUpdateDesignBackground>, PostUpdateDesignBackgroundValidator>();

            services.AddScoped<IValidator<CreateDesignButton>, CreateDesignButtonValidator>();
            services.AddScoped<IValidator<PostUpdateDesignButton>, PostUpdateDesignButtonValidator>();

            services.AddScoped<IValidator<CreateDesignFont>, CreateDesignFontValidator>();
            services.AddScoped<IValidator<PostUpdateDesignFont>, PostUpdateDesignFontValidator>();

            services.AddScoped<IValidator<CreateLanguage>, CreateLanguageValidator>();
            services.AddScoped<IValidator<PostUpdateLanguage>, PostUpdateLanguageValidator>();

            services.AddScoped<IValidator<CreateWord>, CreateWordValidator>();
            services.AddScoped<IValidator<PostUpdateWord>, PostUpdateWordValidator>();

            services.AddScoped<IValidator<CreateSocialMedia>, CreateSocialMediaValidator>();
            services.AddScoped<IValidator<PostUpdateSocialMedia>, PostUpdateSocialMediaValidator>();

            services.AddScoped<IValidator<CreateLink>, CreateLinkValidator>();
            services.AddScoped<IValidator<PostUpdateLink>, PostUpdateLinkValidator>();

            return services;
        }
    }
}
