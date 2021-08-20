
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace API.Models
{
    public class PingEntry
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId _id { get; set; }
        [BsonElement("InstanceKey")]
        public string Key { get; set; }
        [BsonElement("HostIP")]
        public string HostIP { get; set; }
        [BsonElement("Alias")]
        public string Alias { get; set; }
        [BsonElement("ClaimingUser")]
        public ObjectId ClaimingUser { get; set; }
    }
}

