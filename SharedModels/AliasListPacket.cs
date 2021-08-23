using System.Collections.Generic;

namespace SharedModels
{
    public class AliasListPacket
    {
        public RetrievalPacket RetrievalPacket { get; set; }
        public List<string> Aliases { get; set; }

        public bool Success;
    }
}