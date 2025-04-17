using Confluent.Kafka;
using DispatchLogService.services;
using System.Text.Json;

namespace DispatchLogService.Class
{
    public class KafkaConsumer : BackgroundService
    {

        private const string Topic = "test-topic";
        private const string bootstrapServers = "kafka:9092"; //"localhost:29092";
        private const string groupId = "mi-consumer-group"; // Grupo de consumidores

        private readonly ILogger<KafkaConsumer> _logger;
        private readonly MongoDbService mongoService;

        public KafkaConsumer(ILogger<KafkaConsumer> logger, ILogger<MongoDbService> logger2)
        {
            _logger = logger;
            mongoService = new MongoDbService(logger2);
        }

        protected override async Task<string> ExecuteAsync(CancellationToken stoppingToken)
        {
            string result = "";
            var config = new ConsumerConfig
            {
                BootstrapServers = bootstrapServers,
                GroupId = groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest // Para recibir todos los mensajes desde el inicio
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe(Topic);
            CancellationTokenSource cts = CreateCancelationToken();

            try
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    try
                    {
                        var consumeResult = consumer.Consume(cts.Token);
                        _logger.LogInformation($"📩 Mensaje recibido: {consumeResult.Message.Value}");
                        result = consumeResult.Message.Value;
                        DispatchDto dispatch = JsonSerializer.Deserialize<DispatchDto>(result);
                        await mongoService.InsertEvent(dispatch);
                    }
                    catch (ConsumeException e)
                    {
                        _logger.LogInformation($"❌ Error al consumir mensaje: {e.Error.Reason}");
                        result = e.Error.Reason;
                    }

                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("🔻 Consumer detenido.");
                result = "🔻 Consumer detenido.";
            }
            finally
            {
                consumer.Close();

            }
            return result;
        }


        internal CancellationTokenSource CreateCancelationToken() {

            CancellationTokenSource cts = new CancellationTokenSource();
            return cts;
        }

      
    }
}
