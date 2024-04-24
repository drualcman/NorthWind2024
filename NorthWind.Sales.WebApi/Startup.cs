using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace NorthWind.Sales.WebApi;

public static class Startup
{
    public static WebApplication CreateWebApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddNorthWindSalesServices(
            dbOptions => builder.Configuration.GetSection(DbOptions.SectionKey).Bind(dbOptions),
            smtoOptions => builder.Configuration.GetSection(SmtpOptions.SectionKey).Bind(smtoOptions),
            membershipOptions => builder.Configuration.GetSection(MembershipDbOptions.SectionKey).Bind(membershipOptions),
            jwtOptions => builder.Configuration.GetSection(JwtOptions.SectionKey).Bind(jwtOptions));
        builder.Services.AddCors(options => 
        {
            options.AddDefaultPolicy(config => 
            {
                config.AllowAnyHeader();
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
            });
        });

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                builder.Configuration.GetSection(JwtOptions.SectionKey).Bind(options.TokenValidationParameters);
                string securityKey = builder.Configuration
                    .GetSection(JwtOptions.SectionKey)[nameof(JwtOptions.SecurityKey)];
                byte[] secutiryKeyBytes = Encoding.UTF8.GetBytes(securityKey);
                options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(secutiryKeyBytes);
            });
        builder.Services.AddAuthorization();

        return builder.Build();
    }

    public static WebApplication ConfigureWebApplication(this WebApplication app)
    {
        app.UseExceptionHandler(builder => {});

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapNorthWindSalesEndpoints();
        app.UseCors();

        return app;
    }
}
