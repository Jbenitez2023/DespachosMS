using Confluent.Kafka;

namespace DispatchService.Data
{
    public class KafkaProducer : IDisposable
    {
        private readonly IProducer<Null, string> _producer;
        public KafkaProducer(string bootstrapServers)
        {
            var config = new ProducerConfig
            { 
                BootstrapServers = "kafka:9092",//"localhost:9092",
                ClientId = "DispatchProducer"
            };

            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task ProduceAsync(string topic, string message)
        {
            try {
                await _producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            }
            
        }

        public void Dispose()
        {
            _producer.Dispose();
        }
    }
}
