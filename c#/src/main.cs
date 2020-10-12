using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Main
{
    class HttpServer
    {
        public static HttpListener listener;
        public static string url = "http://localhost:8000/";

        public static async Task HandleIncomingConnections()
        {
            bool runServer = true;

            // While a user hasn't visited the `shutdown` url, keep on handling requests
            while (runServer)
            {
                // Will wait here until we hear from a connection
                HttpListenerContext ctx = await listener.GetContextAsync();

                // Peel out the requests and response objects
                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse resp = ctx.Response;


                // Write the response info
                var occurences = HttpServer.GetOccurences();
                var jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(occurences);
                byte[] data = Encoding.UTF8.GetBytes(json);
                resp.ContentType = "application/json";
                resp.ContentEncoding = Encoding.UTF8;
                resp.ContentLength64 = data.LongLength;

                // Write out to the response stream (asynchronously), then close it
                await resp.OutputStream.WriteAsync(data, 0, data.Length);
                resp.Close();
            }
        }

        static void Main(string[] args)
        {
            listener = new HttpListener();
            listener.Prefixes.Add(url);
            listener.Start();
            Console.WriteLine("Listening for connections on {0}", url);

            // Handle requests
            Task listenTask = HandleIncomingConnections();
            listenTask.GetAwaiter().GetResult();
        }

        public static List<Occurence> GetOccurences()
        {
            string text = System.IO.File.ReadAllText("data.txt");

            List<string> parts = new List<string>(text.Split('\n'));
            List<int> numbers = parts.Select(s => int.Parse(s)).ToList();

            numbers.Sort();

            var g = numbers.GroupBy(i => i);

            List<Occurence> occurences = new List<Occurence>();

            foreach (var grp in g)
            {
                occurences.Add(new Occurence(grp.Key, grp.Count()));
            }

            return occurences;
        }

    }
    class Occurence
    {
        public int num { get; set; }
        public int count { get; set; }

        public Occurence(int num, int count)
        {
            this.num = num;
            this.count = count;
        }
    }
}