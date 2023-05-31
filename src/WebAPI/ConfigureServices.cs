using BookingHive.Application.Common.Interfaces;
using BookingHive.Infrastructure.Persistence;
using BookingHive.WebAPI.Filters;
using BookingHive.WebAPI.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NSwag;
using NSwag.Generation.Processors.Security;
using ZymLabs.NSwag.FluentValidation;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddWebAPIServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        // Health Checks
        services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();

        services.AddHealthChecksUI()
                .AddInMemoryStorage();

        services.AddControllersWithViews(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>());

        services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

        services.AddScoped(provider =>
            new FluentValidationSchemaProcessor(provider,
                                                provider.GetService<IEnumerable<FluentValidationRule>>(),
                                                provider.GetService<ILoggerFactory>()));

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddOpenApiDocument((configure, serviceProvider) =>
        {
            // Add the fluent validations schema processor
            configure.SchemaProcessors.Add(
                serviceProvider.CreateScope().ServiceProvider.GetRequiredService<FluentValidationSchemaProcessor>());

            configure.Title = "BookingHive API";

            configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
            {
                Type = OpenApiSecuritySchemeType.ApiKey,
                Name = "Authorization",
                In = OpenApiSecurityApiKeyLocation.Header,
                Description = "Type into the textbox: Bearer {your JWT token}."
            });
        
            configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        });

        return services;
    }
}
