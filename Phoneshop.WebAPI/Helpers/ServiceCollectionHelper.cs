using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Phoneshop.Business;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using PhoneShop.Business.Managers;
using PhoneShop.Contracts.Interfaces;

using PhoneShop.Domain;
using PhoneShop.Shared.Auth;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace PhoneShop.API.Helpers
{
    public static class ServiceCollectionHelper
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DataContext>(
                x => x.UseSqlServer(builder.Configuration.GetConnectionString("phoneshop"))
                    .UseLazyLoadingProxies()
#if DEBUG
                    .LogTo(x => Trace.WriteLine(x))
#endif
            );

            builder.Services.AddSingleton<IJwtAuthManager, JwtAuthManager>();

            builder.Services.AddScoped<IPhoneService, PhoneService>();
            builder.Services.AddScoped<IBrandService, BrandService>();

            builder.Services.AddScoped<IRepository<Phone>, PhoneRepository>();
            builder.Services.AddScoped<IRepository<Brand>, BrandRepository>();

            InitializeMapster();
        }

        /// <summary>
        /// Initializes authentication and authorization
        /// </summary>
        /// <param name="builder"></param>
        public static void InitAuth(this WebApplicationBuilder builder)
        {
            /*
             * Adds the default identity system configuration for the
             * AppUser and AppUserRole classes, as found in our domain (PhoneShop.Domain)
             * Note that the AppUser class inherits from the IdentityUser class
             * and the AppUserRole class inherits from the IdentityRole class
             *
             * Creates an instance of a Microsoft.AspNetCore.Identity.IdentityBuilder,
             * which is used to configure identity services
             */
            builder.Services.AddIdentity<AppUser, AppUserRole>()
                /*
                 * Indicates that the AppUser and AppUserRole represent the
                 * users and roles which Mocrosoft Identity can use for authorization
                */
                .AddEntityFrameworkStores<PhoneShopDbContext>();

            /*
             * Retrieve the jwtTokenConfig section from the appSettings.json (see appSettings.json, line 17) and
             * converts it to an instance of the JwtTokenConfig class.
             *
             * Add the result to the DI servicecollection as a singleton, meaning
             * only one instance exists and is shared amongst all services.
             */
            var jwtTokenConfig = builder.Configuration.GetSection("jwtTokenConfig").Get<JwtTokenConfig>();
            builder.Services.AddSingleton(jwtTokenConfig);

            /*
             * Call authentication helper method provided in Microsoft.AspNetCore.Authentication
             * that initializes all services needed for authentication.
             */
            builder.Services
            .AddAuthentication(options =>
            {
                /*
                * Set the default authentication scheme how it should be provided in the
                * HTTP Authorize header. Defaults to 'Bearer', so the
                * HTTP header would look something like this:
                * Authorization: Bearer abcdefghijklmnopqrstuvwxyz
                */
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                /*
                * Set the default challenge scheme; which scheme
                * to look at to validate that the user has logged in.
                */
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                /*
                * Set the default scheme for everything. This should render
                * the two lines above useless, but the default scheme SHOULD only be
                * used as fallback
                */
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            /*
            * Enables JWT-bearer authentication using the default scheme
            */
            .AddJwtBearer(x =>
            {
                /*
                * Gets or sets if HTTPS is required for the metadata address or authority.
                * The default is true. This should be disabled only in development environments.
                */
                x.RequireHttpsMetadata = true;
                // Set the parameters used to validate identity tokens.
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    /*
                    * Since a JWT is basically an object that anyone could manufacture,
                    * make sure that we're the one having issued the token
                    */
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,

                    /*
                    * Determines wether or not to validate the signing key (3rd part of the JWT, remember?)
                    */
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),

                    /*
                    * Validate the audience. Currently it's set to *, indicating
                    * everyone is valid as audience.
                    */
                    ValidateAudience = true,
                    ValidAudience = jwtTokenConfig.Audience,

                    /*
                    * Validate the lifetime of tokens, with a 1 minute 'grace period'
                    */
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });
        }

        private static void InitializeMapster()
        {
            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            Assembly applicationAssembly = typeof(DTOBase<>).Assembly;
            typeAdapterConfig.Scan(applicationAssembly);
        }
    }
}