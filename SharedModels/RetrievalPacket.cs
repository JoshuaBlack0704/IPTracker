
namespace SharedModels
{
    public class RetrievalPacket
    {
        public AuthPacket AuthPacket { get; set; }
        public string Alias { get; set; }
        public string Ip { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}


