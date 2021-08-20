using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using SharedModels;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IConfiguration configuration;

        public AuthController(IConfiguration config)
        {
            this.configuration = config;
        }

        [HttpPost]
        public async Task<AuthPacket> Login(AuthPacket packet)
        {
            var server = new MongoDataAccess.MongoContext(configuration.GetConnectionString("mongo"));
            packet.Success = await MongoDataAccess.MongoUserManager.CheckCredentialsAny(server, packet.UserName, packet.Password) != ObjectId.Empty;
            Task.Run(() => Console.WriteLine($"Recieved request for username: {packet.UserName} with result: {packet.Success}"));
            return packet;
        }
    }
}

