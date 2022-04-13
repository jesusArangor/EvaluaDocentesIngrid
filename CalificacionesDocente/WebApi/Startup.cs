using Datos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Modelo.Interfaces;
using Modelo.Modelos;
using Servicios;
using System;
using System.Text;
using WebApi.Helpers;

namespace WebApi
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

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // configure DI for application services
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IDataReader<Curso, int>, CursoDb>();

            services.AddScoped<IDataReader<Facultad, int>, FacultadDb>();
            services.AddScoped<IDataReader<Formato, int>, FormatoDb>();
            services.AddScoped<IDataReader<Programa, int>, ProgramaDb>();
            services.AddScoped<IDataReader<Sede, int>, SedeDb>();
            services.AddScoped<IDataReader<Usuario, int>, UsuarioDb>();
            services.AddScoped<IUsuarioData, UsuarioDb>();
            services.AddScoped<IDataReader<Evaluacion, int>, EvaluancionDb>();
            services.AddScoped<IEvaluacionData, EvaluancionDb>();

            services.AddSingleton(_ => Configuration);
            AddSwagger(services);
            services.AddControllers();


            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme =  JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    
                    ValidIssuer = Configuration["JwtToken:Issuer"],
                    ValidAudience = Configuration["JwtToken:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtToken:SecretKey"]))
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // @"Data Source = YourDatabaseServerAddress;initial catalog=YourDatabaseName;user id=YourDatabaseLoginId;password=YourDatabaseLoginPassword"
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseMiddleware<JwtMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Evalua Docentes {groupName}",
                    Version = groupName,
                    Description = "Evalua Docentes API",
                    Contact = new OpenApiContact
                    {
                        Name = "Evalua Docentes",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/jesusArangor/EvaluaDocentesIngrid"),
                    }
                });
            });
        }
    }
}