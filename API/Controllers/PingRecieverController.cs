using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;

namespace API.Controllers
{
    using Microsoft.Extensions.Configuration;
    using Models;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System.Threading.Tasks;

    [Route("api/ping")]
    [ApiController]
    public class PingRecieverController : ControllerBase
    {
        private IConfiguration configuration;
        private MongoDataAccess.MongoContext server;

        public PingRecieverController(IConfiguration config, MongoDataAccess.MongoContext s)
        {
            configuration = config;
            server = s;
        }
        [HttpPost]
        public async Task RecievePing([FromBody]string clientKey)
        {
            string host = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            Task.Run(() => Console.WriteLine($"Recieved ping from {host}"));
            await AddPing(server, clientKey, host);
        }

        public async Task AddPing(MongoDataAccess.MongoContext server, string clientKey, string hostIP)
        {
            server.SetDatabase("ExternalIPTracking");
            var pings = server.database.GetCollection<PingEntry>("Pings");
            var pingFilter = Builders<PingEntry>.Filter.Eq("InstanceKey", clientKey);
            long pingCount = 0;
            pingCount = await pings.CountDocumentsAsync(pingFilter);
            var pingExists = pingCount > 0;

            if (pingExists && pingCount == 1)
            {
                //Console.WriteLine("ClientKey already exists, updating");
                var updateFilter = Builders<PingEntry>.Filter.Eq("InstanceKey", clientKey);
                var updateDefinition = Builders<PingEntry>.Update.Set("HostIP", hostIP);
                await pings.UpdateOneAsync(updateFilter, updateDefinition);
            }
            else if (pingExists && pingCount > 1)
            {
                //Console.WriteLine("More than one identical key, deleting");
                pings.DeleteMany(pingFilter);
                var ping = new PingEntry()
                {
                    HostIP = hostIP,
                    Key = clientKey,
                    Alias = "",
                    ClaimingUser = ObjectId.Empty,
                };
                await pings.InsertOneAsync(ping);
            }
            else
            {
                var ping = new PingEntry()
                {
                    HostIP = hostIP,
                    Key = clientKey,
                    Alias = "",
                    ClaimingUser = ObjectId.Empty,
                };
                await pings.InsertOneAsync(ping);
            }
        }

        
    }

    
}
