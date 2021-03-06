using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Customers_Payments_Report.Repository;
using Customers_Payments_Report.Repository.Interface;
using Customers_Payments_Report.Repository.Class;
using Customers_Payments_Report.Models.common;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;

namespace Customers_Payments_Report
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder => builder.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

            services.AddControllers();
            services.AddScoped<IGetData, GetData>();
            services.AddScoped<IGeneralSettingsRepository, GeneralSettingsRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IAuthenticateRepository, AuthenticateRepository>();


            var appSettingsSection = Configuration.GetSection("AppSetting");
            services.Configure<AppSetting>(appSettingsSection);

            //JWT Authentication
            var appSetting = appSettingsSection.Get<AppSetting>();
            var key = Encoding.ASCII.GetBytes(appSetting.Key);

            services.AddAuthentication(au =>
            {
                au.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                au.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseCors(builder => builder
            //  .AllowAnyHeader()
            //  .AllowAnyMethod()
            //  .SetIsOriginAllowed((host) => true)
            //  .AllowCredentials()
            //  );

            app.UseRouting();
            app.UseCors();
            //  app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("could not found any thing");
            });
        }
    }
}
