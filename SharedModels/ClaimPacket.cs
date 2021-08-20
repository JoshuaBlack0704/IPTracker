namespace SharedModels
{
    public class ClaimPacket
    {
        public AuthPacket AuthPacket { get; set; }
        public string InstanceID { get; set; }
        public string Alias { get; set; }
        public bool Success { get; set; }
    }
}


