using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PingMaster
{
    using MongoDB.Bson;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading;
    using SharedModels;

    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static Random random = new Random();
        static string proccessKey;
        static void Main(string[] args)
        {
            if (File.Exists("key.txt") == false)
            {
                Console.WriteLine("Creating new key:\n");
                using (FileStream fs = File.Create("key.txt"))     
                {    
                    // Add some text to file    
                    Byte[] key = new UTF8Encoding(true).GetBytes(BCrypt.Net.BCrypt.HashPassword(random.Next(0, int.MaxValue).ToString(), 11));    
                    fs.Write(key, 0, key.Length);    
                } 
            }
            else
            {
                Console.WriteLine("pre-generated key found:\n");
            }

            string letter;
            using (StreamReader sr = File.OpenText("key.txt"))     
            {
                while ((letter = sr.ReadLine()) != null)
                {
                    proccessKey += letter;
                }
            } 
            
            Console.WriteLine(proccessKey + "\n");
            
            var endpoint = Environment.GetEnvironmentVariable("Endpoint");

            Console.WriteLine($"Using URL: {endpoint}");
            client.BaseAddress = new Uri(endpoint);
            void Ping()
            {
                var x = Task.Run(() => client.PostAsJsonAsync(client.BaseAddress, proccessKey));
                x.Wait();
                var response = x.Result;
                var message = Task.Run(() => response.Content.ReadFromJsonAsync<PingResponse>());
                message.Wait();
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
                Thread.Sleep(60000);
            }

        }

    }
}
