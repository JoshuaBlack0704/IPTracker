using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using SharedModels;

namespace API.Controllers
{
    [Route("api/list")]
    [ApiController]
    public class AliasListController : ControllerBase
    {
        IConfiguration configuration;

        public AliasListController(IConfiguration config)
        {
            this.configuration = config;
        }

        public async Task<AliasListPacket> GetAliasList(AliasListPacket packet)
        {
            var server = new MongoDataAccess.MongoContext(configuration.GetConnectionString("mongo"));
            var auth = await server.CheckCredentialsAny(packet.RetrievalPacket.AuthPacket.UserName, packet.RetrievalPacket.AuthPacket.Password);
            packet.RetrievalPacket.AuthPacket.Success = auth != ObjectId.Empty;
            if (packet.RetrievalPacket.AuthPacket.Success == false)
            {
                Console.WriteLine($"User: {packet.RetrievalPacket.AuthPacket.UserName} failed to authorize");
                packet.Success = false;
                return packet;
            }
            
            
            server.SetDatabase("ExternalIPTracking");
            var pings = server.database.GetCollection<PingEntry>("Pings");
            var userFilter = Builders<PingEntry>.Filter.Eq("ClaimingUser", auth);
            var isReal = await pings.CountDocumentsAsync(userFilter) > 0;
            
            if (isReal)
            {
                Console.WriteLine("User has aliases");
                var pingCursor = await pings.FindAsync(userFilter);
                var pingList = await pingCursor.ToListAsync();
                foreach (var ping in pingList)
                {
                    packet.Aliases.Add(ping.Alias);
                }
                packet.Success = true;
                return packet;
            }

            Console.WriteLine("User does not own any aliases");
            packet.Success = false;
            return packet;
        }
    }
}