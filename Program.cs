using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Web;

namespace MyFirstConsole
{

    class Tanques
    {
        public string tipo { get; set; }
        public string produto { get; set; }
        public string situacao { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Por padrao o Programa vai ler o arquivo que estah na pasta /bin/Debug/netcoreapp3.1/
            // para corrigir, basta sair das 3 pastas como abaixo:
            var json = File.ReadAllText("../../../dados.json");
            
 
            // JavaScriptSerializer serialized = new JavaScriptSerializer();
            var serialized = JObject.Parse(json);
            var tanquesObjects = serialized["tanques"].ToObject<Tanques[]>();

            foreach (var tanque in tanquesObjects)
            {
                Console.WriteLine(tanque.produto);
                Console.WriteLine(tanque.situacao);
                Console.WriteLine(tanque.tipo);
                Console.WriteLine("__________________________");
            }


            Console.ReadLine();
        }
    }
}
