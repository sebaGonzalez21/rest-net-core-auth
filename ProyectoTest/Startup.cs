using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProyectoTest.Dummy;
using ProyectoTest.Imp;
using ProyectoTest.Service;
using ProyectoTest.Util;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;
/**
* SebastianGonzalez
* 
* */
namespace ProyectoTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /**
         * Invocacion del appsettings
         */
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //politica de cors
            services.AddCors(o => o.AddPolicy(Constant.CORS, builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 5001;
            });


            /**
             * Conexion a la base de datos
             * 
            services.AddDbContext<GenericContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString(Constants.NameConnection),

                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.UseRowNumberForPaging();
                        sqlOptions.
                        MigrationsAssembly(
                            typeof(Startup).
                             GetTypeInfo().
                              Assembly.
                               GetName().Name);

                            //Configuring Connection Resiliency:
                            sqlOptions.
                                    EnableRetryOnFailure(maxRetryCount: 5,
                                    maxRetryDelay: TimeSpan.FromSeconds(30),
                                    errorNumbersToAdd: null);

                    });



                // Changing default behavior when client evaluation occurs to throw.
                // Default in EFCore would be to log warning when client evaluation is done.
                options.ConfigureWarnings(warnings => warnings.Throw(
                        RelationalEventId.QueryClientEvaluationWarning));
            });
            */

            // configure jwt authentication
            //var appSettings = appSettingsSection.Get<AppSettings>();
            var nombre = Configuration.GetConnectionString(Constant.SECRET);
            //const string sec = "601b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb3375914bd3e44453b954555b7a0812e1081c39b740253f765eae731f5a65ed1";
            //Configuration.GetConnectionString(Constant.SECRET)
            var key = Encoding.ASCII.GetBytes(Configuration.GetConnectionString(Constant.SECRET));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddTransient<IClientService, ImpClient>();
            services.AddTransient<IUserService, ImpUser>();
            services.AddTransient<IDummyService, UserDummy>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "SGS Api",
                    Description = "ASP.NET Core Web API for Test"

                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //politica de cors
            app.UseCors(Constant.CORS);
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            //app.UseJwtBearerAuthentication();


            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
                c.RoutePrefix = "swagger";
            });
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
