using System;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Pang.RBAC.Api.Data;
using Pang.RBAC.Api.Repository.Base;

namespace Pang.RBAC.Api
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

            services.AddControllers(setup =>
            {
                setup.ReturnHttpNotAcceptable = true;
                // 添加XML
                // setup.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                // 将默认格式改为XML
                // setup.OutputFormatters.Insert(0, new XmlDataContractSerializerOutputFormatter());
            }).AddNewtonsoftJson(setup =>
                {
                    setup.SerializerSettings.ContractResolver
                        = new CamelCasePropertyNamesContractResolver();
                })
                /*添加XML*/.AddXmlDataContractSerializerFormatters()
                .ConfigureApiBehaviorOptions(setup =>
                {
                    setup.InvalidModelStateResponseFactory = context =>
                    {
                        var problemDetails = new ValidationProblemDetails(context.ModelState)
                        {
                            Type = "http://www.baidu.com",
                            Title = "有错误",
                            Status = StatusCodes.Status422UnprocessableEntity,
                            Detail = "请看详细信息",
                            Instance = context.HttpContext.Request.Path
                        };

                        problemDetails.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

                        return new UnprocessableEntityObjectResult(problemDetails)
                        {
                            ContentTypes = { "application/problem+json" }
                        };
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pang.RBAC.Api", Version = "v1" });

                // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                // //... and tell Swagger to use those XML comments.
                // c.IncludeXmlComments(xmlPath);
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<PangDbContext>(opts =>
            {
                opts.UseSqlite("Data Source=Pang.db");
            });

            services.AddCors(opts =>
            {
                opts.AddPolicy("Any", builder =>
                {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                });
            });

            // 身份认证配置
            var validAudience = Configuration["audience"];
            var validIssuer = Configuration["issuer"];
            var securityKey = Configuration["secret"];
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = validAudience,
                        ValidIssuer = validIssuer,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey))
                    };
                });

            var types = Assembly.GetExecutingAssembly().GetTypes().AsEnumerable();
            var repositorys = types.Where(t => t.Namespace == "Pang.RBAC.Api.Repository" && !t.IsAbstract && !t.IsInterface);

            foreach (var repo in repositorys)
            {
                services.AddScoped(repo);
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pang.RBAC.Api v1"));

            // app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("Any");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
