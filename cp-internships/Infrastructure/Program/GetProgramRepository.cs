using Domain.Program.Get;
using Domain.Shared;
using Microsoft.Azure.Cosmos;

namespace Infrastructure.Respository.Program
{
    public class GetProgramRepository : IGetProgramRepository
    {
        private readonly CosmosClient _client;
        private static readonly string dbname = "internships";
        private static readonly string containername = "programs";
        public GetProgramRepository(CosmosClient client)
        {
            _client = client;
        }

        public async Task<Result<GetProgramDTO>> GetProgramById(string id, CancellationToken cancellationToken)
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

                ItemResponse<GetProgramDTO> response = await container.ReadItemAsync<GetProgramDTO>(
                      id: id,
                      partitionKey: new PartitionKey(id),
                      null,
                      cancellationToken: cancellationToken
                  );
                return Result.Success<GetProgramDTO>(response.Resource);
            }
            catch (CosmosException e)
            {

                return Result.Failure<GetProgramDTO>(new Error(Code: e.StatusCode.ToString(), Description: e.Message));
            }
            


            

        }
    }
}
