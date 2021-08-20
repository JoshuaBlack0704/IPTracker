using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SharedModels;
using API.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/fetch")]
    [ApiController]
    public class PingFetcherController : ControllerBase
    {
        private IConfiguration configuration;

        public PingFetcherController(IConfiguration config)
        {
            configuration = config;
        }

        [HttpPost]
        public async Task<RetrievalPacket> FetchIp(RetrievalPacket packet)
        {
            var server = new MongoDataAccess.MongoContext(configuration.GetConnectionString("mongo"));
            var auth = await MongoDataAccess.MongoUserManager.CheckCredentialsAny(server, packet.AuthPacket.UserName, packet.AuthPacket.Password);
            packet.AuthPacket.Success = auth != ObjectId.Empty;
            if (packet.AuthPacket.Success == false)
            {
                packet.Success = false;
                return packet;
            }

            server.SetDatabase("ExternalIpTracking");
            var pings = server.database.GetCollection<PingEntry>("Pings");
            var keyFilter = Builders<PingEntry>.Filter.Eq("Alias", packet.Alias);
            var isReal = await pings.CountDocumentsAsync(keyFilter) > 0;

            if (isReal)
            {
                var pingCursor = await pings.FindAsync(keyFilter);
                var ping = pingCursor.First();

                if (ping.ClaimingUser == auth)
                {
                    packet.Ip = ping.HostIP;
                    packet.Success = true;
                    return packet;
                }

                packet.Success = false;

            }

            packet.Success = false;
            return packet;
        }
    }
}


