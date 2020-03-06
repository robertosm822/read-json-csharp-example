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
            //Console.WriteLine("This is my First Console App \n Digite seu nome");
           // string resposta = Console.ReadLine();
           // Console.WriteLine("Hello,"+ resposta);
            var json = File.ReadAllText("dados.json");
            
 
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
