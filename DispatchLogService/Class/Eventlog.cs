using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DispatchLogService.Class
{
    public class Eventlog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Status { get; set; }
        public DateTime Timestamp { get; set; }

        public DispatchDto DispatchDto { get; set; }
    }
}
