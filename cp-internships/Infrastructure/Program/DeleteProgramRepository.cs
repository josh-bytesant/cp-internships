using Domain.Program.Delete;
using Domain.Shared;
using Microsoft.Azure.Cosmos;

namespace Infrastructure.Respository.Program
{
    public class DeleteProgramRepository : IDeleteProgramRepository
    {
        private readonly CosmosClient _client;
        private static readonly string dbname = "internships";
        private static readonly string containername = "programs";
        public DeleteProgramRepository(CosmosClient client)
        {
            _client = client;
        }

        public async Task<Result<int>> Delete(string id, CancellationToken cancellationToken)
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
                Container container = await database.CreateContainerIfNotExistsAsync(containerProperties, throughput);

                var result = await container.DeleteItemAsync<Domain.Program.Entities.Program>(id, new PartitionKey(id), null, cancellationToken);
                return (int)result.StatusCode;
            }
            catch (CosmosException e)
            {
                return Result.Failure<int>(new Error(Code: e.StatusCode.ToString(), Description: e.Message));
            }
        }
    }
}
