using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using uprox.models;
using System.Collections.Generic;
using System.IO;

namespace uProx
{
    class Program
    {
        const string targetUrl = "http://www.unarix.com.ar";

        static void Main(string[] args)
        {
            Console.WriteLine("targetUrl url: " + targetUrl);
            Task.Run(new Action(DownloadPageAsync));
            Console.ReadLine();
        }

        static async void DownloadPageAsync()
        {

            var read = File.ReadAllText("proxylist.json");
            List<proxy> objetos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<proxy>>(read);
            
            foreach(proxy p in objetos)
            {
                Console.WriteLine(" >> Usando proxy " + p.ip + " puerto: " + p.port);

                var webProxy = new WebProxy(p.ip,int.Parse(p.port));

                var proxyHttpClientHandler = new HttpClientHandler {Proxy = webProxy,UseProxy = true,};

                try{
                    using (HttpClient client = new HttpClient(proxyHttpClientHandler))
                    using (HttpResponseMessage response = await client.GetAsync(targetUrl))
                    using (HttpContent content = response.Content)
                    {                                
                        string result = await content.ReadAsStringAsync();

                        if (result != null && result.Length >= 50)
                        {
                            Console.WriteLine("    " + result.Substring(0, 3000) + "...");
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("fin de lista de proxys alcanzado... ");
        }

        // Ejemplo de como escribir una entidad a json
        private void writejson()
        {
            List<proxy> proxys = new List<proxy>();
            proxy prox = new proxy();
            prox.ip = "10.10.10.10";
            prox.port = "10001";
            proxys.Add(prox);
            
            proxy prox2 = new proxy();
            prox2.ip = "10.10.10.10";
            prox2.port = "10001";
            proxys.Add(prox);

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(proxys);

            string filePath = "proxylist.json";
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(System.IO.File.Create(filePath)))
            {
                file.WriteLine(output);
            }
        }

    }
}
