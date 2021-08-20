using Microsoft.AspNetCore.Mvc;
using SharedModels;
using API.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/claim")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private IConfiguration configuration;

        public ClaimController(IConfiguration config)
        {
            configuration = config;
        }

        [HttpPost]
        public async Task<ClaimPacket> ClaimKey(ClaimPacket packet)
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
            var keyFilter = Builders<PingEntry>.Filter.Eq("InstanceKey", packet.InstanceID);
            var isReal = await pings.CountDocumentsAsync(keyFilter) > 0;

            if (isReal)
            {
                var pingCursor = await pings.FindAsync(keyFilter);
                var ping = pingCursor.First();
                if (ping.ClaimingUser != ObjectId.Empty)
                {
                    packet.Success = false;
                    return packet;
                }

                var updateUser = Builders<PingEntry>.Update.Set("ClaimingUser", auth);
                var updateAlias = Builders<PingEntry>.Update.Set("Alias", packet.Alias);

                await pings.FindOneAndUpdateAsync(keyFilter, updateUser);
                await pings.FindOneAndUpdateAsync(keyFilter, updateAlias);

                packet.Success = true;
                return packet;
            }

            packet.Success = false;
            return packet;

        }
    }
}

