using System;
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
            Console.WriteLine($"Recieved request for address of alias: {packet.Alias} from user: {packet.AuthPacket.UserName}");
            var server = new MongoDataAccess.MongoContext(configuration.GetConnectionString("mongo"));
            var auth = await server.CheckCredentialsAny(packet.AuthPacket.UserName, packet.AuthPacket.Password);
            packet.AuthPacket.Success = auth != ObjectId.Empty;
            if (packet.AuthPacket.Success == false)
            {
                Console.WriteLine("User failed to authenticate");
                packet.Success = false;
                return packet;
            }

            server.SetDatabase("ExternalIPTracking");
            var pings = server.database.GetCollection<PingEntry>("Pings");
            var keyFilter = Builders<PingEntry>.Filter.Eq("Alias", packet.Alias);
            var isReal = await pings.CountDocumentsAsync(keyFilter) > 0;

            if (isReal)
            {
                Console.WriteLine("Alias exists");
                var pingCursor = await pings.FindAsync(keyFilter);
                var ping = pingCursor.First();

                if (ping.ClaimingUser == auth)
                {
                    packet.Ip = ping.HostIP;
                    packet.LastUpdated = ping.LastUpdated;
                    packet.Success = true;
                    return packet;
                }
                Console.WriteLine($"User has no claim on Alias: {packet.Alias}");
                packet.Success = false;
                return packet;
            }

            Console.WriteLine("Alias does not exist");
            packet.Success = false;
            return packet;
        }
    }
}


