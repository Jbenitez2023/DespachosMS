using DispatchLogService.Class;
using MongoDB.Driver;

namespace DispatchLogService.services
{
    public class MongoDbService
    {
        private readonly ILogger<MongoDbService> _logger;
        private readonly IMongoCollection<Eventlog> _logCollection;

        public MongoDbService(ILogger<MongoDbService> logger)
        {
            _logger = logger;
            _logger.LogInformation($"conectando a mongo");
            var client = new MongoClient("mongodb://host.docker.internal:27017");
            
            _logger.LogInformation($"conectando a dispatchdb");
            var database = client.GetDatabase("dispatchdb");

            _logCollection = database.GetCollection<Eventlog>("log");
        }


        public async Task InsertEvent(DispatchDto eventlog)
        {
            Eventlog eventLog = new Eventlog
            {
                Timestamp = DateTime.Now,
                DispatchDto = eventlog
            };



            _logger.LogInformation("Datos de collection : " + _logCollection.ToString());
            await _logCollection.InsertOneAsync(eventLog);
        }

    }
}
