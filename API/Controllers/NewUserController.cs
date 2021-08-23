using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SharedModels;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class NewUserController : ControllerBase
    {
        IConfiguration configuration;

        public NewUserController(IConfiguration config)
        {
            this.configuration = config;
        }

        [HttpPost]
        public async Task<AuthPacket> AddNewUser(AuthPacket packet)
        {
            var server = new MongoDataAccess.MongoContext(configuration.GetConnectionString("mongo"));
            packet.Success = await server.AddNewUserAsync(packet.UserName, packet.Password);
            Console.WriteLine($"Recieved request for for new user: {packet.UserName} with result: {packet.Success}");
            return packet;
        }
    }
}

