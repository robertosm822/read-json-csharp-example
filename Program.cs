using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Web;

namespace MyFirstConsole
{

    class Tanques
    {
        public string tipo { get; set; }
        public string produto { get; set; }
        public string situacao { get; set; }
    }
    class Users
    {
        /*
            Campos escolhidos da API:
            "id": 1,
            "name": "Leanne Graham",
            "username": "Bret",
         */
         public string id { get; set; }
         public string name { get; set; }
         public string username { get; set; }
    }

    public class ListUsersFormJson
    {
        
        public void load() {
            // consumindo api json
            string jsonUrl = new WebClient().DownloadString("https://jsonplaceholder.typicode.com/users");
            Users[] users = JsonConvert.DeserializeObject<Users[]>(jsonUrl);

            // mostrando os usuarios
            Console.WriteLine("__________________________");
            Console.WriteLine("==== Usuarios - List ====");
            Console.WriteLine("__________________________");

            foreach (var user in users)
            {
                Console.WriteLine(user.id);
                Console.WriteLine(user.name);
                Console.WriteLine(user.username);
                Console.WriteLine("__________________________");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Por padrao o Programa vai ler o arquivo que estah na pasta /bin/Debug/netcoreapp3.1/
            // para corrigir, basta sair das 3 pastas como abaixo:
            var json = File.ReadAllText("../../../dados.json");
            var serialized = JObject.Parse(json);
            var tanquesObjects = serialized["tanques"].ToObject<Tanques[]>();

            foreach (var tanque in tanquesObjects)
            {
                Console.WriteLine(tanque.produto);
                Console.WriteLine(tanque.situacao);
                Console.WriteLine(tanque.tipo);
                Console.WriteLine("__________________________");
            }

            // carregar lista de Users de URL json
            new ListUsersFormJson().load();

            Console.ReadLine();
        }
    }
}
