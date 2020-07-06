using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using RestWithAspNetUdemy.Model.Contexto;
using RestWithAspNetUdemy.Repository.Generic;
using RestWithAspNetUdemy.Repository.Implementacao;
using RestWithAspNetUdemy.Servicos.Implementacao;
using Serilog;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RestWithAspNetUdemy
{
    public class Startup
    {
       // public readonly ILogger _logger;
        public IConfiguration _configuration { get; }
        public IHostEnvironment _environment { get; }
        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
            //_logger = logger;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["MySQLConnection:MySQLConnection"];
            services.AddDbContext<MySQLContexto>(options => options.UseMySql(connectionString));

            Log.Logger = new LoggerConfiguration()
              .CreateLogger();

            try
            {
                
                IDbConnection dbConnection = new MySqlConnection(connectionString);

                var evolve = new Evolve.Evolve(dbConnection, msg => Log.Information(msg))
                {
                    Locations = new[] { "DB/migrations" },
                    IsEraseDisabled = true,
                    Placeholders = new Dictionary<string, string>
                    {
                        ["${table4}"] = "table4"
                    }

                };

                evolve.Migrate();
            }
            catch (System.Exception ex)
            {
                Log.Error("Falha na migracao da Banco de Dados", ex);
                throw;
            }

            //if (_environment.IsDevelopment())
            //{
            //    try
            //    {
            //        //var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            //        //var cnx = new SqliteConnection(_configuration.GetConnectionString("restwithaspnetudemy"));

            //        var evolve = new Evolve.Evolve(dbConnection, msg => _logger.LogInformation(msg))
            //        {
            //            Locations = new[] { "db/migrations" },
            //            IsEraseDisabled = true,
            //            Placeholders = new Dictionary<string, string>
            //            {
            //                ["${table4}"] = "table4"
            //            }

            //        };

            //        evolve.Migrate();
            //    }
            //    catch (System.Exception ex)
            //    {
            //        _logger.LogCritical("Falha na migracao da Banco de Dados", ex);
            //        throw;
            //    }
            //}

            services.AddControllers();

            services.AddApiVersioning();

            services.AddScoped<IPessoaServico, PessoaServicoImplentacao>();
            services.AddScoped<IPessoaRepository, PessoaRepositoryImplentacao>();

            services.AddScoped<ILivroServico, LivroServicoImplentacao>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
