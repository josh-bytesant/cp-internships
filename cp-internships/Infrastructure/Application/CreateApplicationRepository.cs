using Domain.Application.Create;
using Domain.Shared;
using Microsoft.Azure.Cosmos;

namespace Infrastructure.Respository.Application.Implementations
{
    public  class CreateApplicationRepository : ICreateApplicationRepository
    {
        private readonly CosmosClient _client;
        private static readonly string dbname = "internships";
        private static readonly string containername = "applications";

        public CreateApplicationRepository(CosmosClient client)
        {
            _client = client;
        }

        public async Task<Result> Create(Domain.Application.Entities.Application application, CancellationToken cancellationToken)
        {
            try
            {
                Database database = await _client.CreateDatabaseIfNotExistsAsync(dbname);
                ContainerProperties containerProperties = new ContainerProperties()
                {
                    Id = containername,
                    PartitionKeyPath = "/ProgramId"
                };

                var throughput = ThroughputProperties.CreateManualThroughput(400);
                Microsoft.Azure.Cosmos.Container container = await database.CreateContainerIfNotExistsAsync(containerProperties, throughput);


                var result = await container.CreateItemAsync<Domain.Application.Entities.Application>(application, new PartitionKey(application.ProgramId), null, cancellationToken);
                return Result.Success();
            }
            catch (CosmosException e)
            {

                return Result.Failure<int>(new Error(Code: e.StatusCode.ToString(), Description: e.Message));
            }
        }
    }
}
