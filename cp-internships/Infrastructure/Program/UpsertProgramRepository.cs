using Domain.Program.Shared;
using Domain.Shared;
using Microsoft.Azure.Cosmos;

namespace Infrastructure.Respository.Program.Implementations
{
    public class UpsertProgramRepository : IUpsertProgramRepository
    {
        private readonly CosmosClient _client;
        private static readonly string dbname = "internships";
        private static readonly string containername = "programs";
        public UpsertProgramRepository(CosmosClient client)
        {
            _client = client;
        }

        public async Task<Result<int>> Upsert(Domain.Program.Entities.Program program, CancellationToken cancellationToken)
        {   
            try
            {
                Database database = await _client.CreateDatabaseIfNotExistsAsync(dbname);
                ContainerProperties containerProperties = new ContainerProperties()
                {
                    Id = containername,
                    PartitionKeyPath = "/id"
                };

                var throughput = ThroughputProperties.CreateManualThroughput(400);
                Microsoft.Azure.Cosmos.Container container = await database.CreateContainerIfNotExistsAsync(containerProperties, throughput);


                var result = await container.UpsertItemAsync<Domain.Program.Entities.Program>(program, new PartitionKey(program.id), null, cancellationToken);
                return (int)result.StatusCode;
            }
            catch (CosmosException e)
            {

                return Result.Failure<int>(new Error(Code: e.StatusCode.ToString(), Description: e.Message));
            }
        }
    }
}
