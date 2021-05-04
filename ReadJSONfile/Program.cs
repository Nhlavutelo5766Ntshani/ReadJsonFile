using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadJson();
            Console.ReadLine();
        }

        public static void ReadJson()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\Helton\Downloads\basic_endpoints.json"))
            {
                string json = r.ReadToEnd();

                dynamic jsonObj = JsonConvert.DeserializeObject(json);

                //Call to the first service and first endpoint
                try
                {
                    WebRequest req = WebRequest.Create(jsonObj.services[0].baseURL.ToString() + jsonObj.services[0].endpoints[0].resource.ToString());
                    WebResponse res = req.GetResponse();

                    StreamReader reader = new StreamReader(res.GetResponseStream());
                    dynamic responseObj = JsonConvert.DeserializeObject(reader.ReadLine());
                    Console.WriteLine(responseObj);

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.ReadLine();
                }
               
               // ----------------------------------------------------------------------------------------
                //Call to the first service and second endpoint
                //WebRequest req = WebRequest.Create(jsonObj.services[0].baseURL.ToString() + jsonObj.services[0].endpoints[0].resource.ToString());
                //WebResponse res = req.GetResponse();

                //StreamReader reader = new StreamReader(res.GetResponseStream());
                //dynamic responseObj = JsonConvert.DeserializeObject(reader.ReadLine());
                //Console.WriteLine(responseObj);

                //----------------------------------------------------------------------------------------
                ////Call to the second service and its endpoint
                //WebRequest req = WebRequest.Create(jsonObj.services[1].baseURL.ToString() + jsonObj.services[1].endpoints[0].resource.ToString());
                //WebResponse res = req.GetResponse();

                //StreamReader reader = new StreamReader(res.GetResponseStream());
                //dynamic responseObj = JsonConvert.DeserializeObject(reader.ReadLine().ToString());
                //Console.WriteLine(responseObj);



            }
        }
    }
    class Services
    {
        public string baseURL { get; set; }
        public bool enabled { get; set; }
        public List<Endpoints> endpoints { get; set; }

    }

    class Endpoints
    {
        public bool enabled { get; set; }
        public string resource { get; set; }
        public List<Response> response { get; set; }

    }

    class Response
    {
        public string element { get; set; }
        public string Regex { get; set; }
    }
}