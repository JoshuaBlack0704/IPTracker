
using System;

namespace SharedModels
{
    public class RetrievalPacket
    {
        public AuthPacket AuthPacket { get; set; }
        public string Alias { get; set; }
        public string Ip { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Success { get; set; }
    }
}


