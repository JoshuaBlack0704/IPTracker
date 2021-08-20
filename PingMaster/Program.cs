using System;
using System.Threading.Tasks;

namespace PingMaster
{
    using MongoDB.Bson;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading;

    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static Random random = new Random();
        static string proccessKey;
        static void Main(string[] args)
        {
            proccessKey = BCrypt.Net.BCrypt.HashPassword(random.Next(0, int.MaxValue).ToString(), 11);
            Console.WriteLine(proccessKey);
            client.BaseAddress = new Uri("http://localhost:5005/api/ping");
            void Ping()
            {
                var x = Task.Run(() => client.PostAsJsonAsync(client.BaseAddress, proccessKey));
                x.Wait();
            }


            while (true)
            {
                try
                {
                    Ping();
                }
                catch (Exception)
                {
                    Console.WriteLine("\nTimeout\n");
                    Console.WriteLine(proccessKey);
                }
                Thread.Sleep(1000);
            }

        }

    }
}
