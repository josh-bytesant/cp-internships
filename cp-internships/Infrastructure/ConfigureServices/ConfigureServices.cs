using Domain.Application.Create;
using Domain.Program.Create;
using Domain.Program.Delete;
using Domain.Program.Get;
using Domain.Program.Shared;
using Domain.Program.Update;
using Infrastructure.Respository.Application.Implementations;
using Infrastructure.Respository.Program.Implementations;
using Infrastructure.Respository.Program;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ConfigureServices
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUpsertProgramRepository, UpsertProgramRepository>();
            services.AddScoped<IGetProgramRepository, GetProgramRepository>();
            services.AddScoped<IDeleteProgramRepository, DeleteProgramRepository>();
            services.AddScoped<ICreateApplicationRepository, CreateApplicationRepository>();
            services.AddScoped<CreateProgramService>();
            services.AddScoped<UpdateProgramService>();
            services.AddScoped<DeleteProgramService>();
            services.AddScoped<GetProgramByIdService>();
            services.AddScoped<CreateApplicationService>();
            services.AddSingleton<CosmosClient>(serviceProvider =>
            {
                IHttpClientFactory httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();

                CosmosClientOptions cosmosClientOptions = new CosmosClientOptions
                {
                    HttpClientFactory = httpClientFactory.CreateClient,
                    ConnectionMode = ConnectionMode.Gateway
                };


                return new CosmosClient(configuration["ConnectionStrings:cosmosdb_connection"], cosmosClientOptions);
            });
            return services;
        }
    }
}
