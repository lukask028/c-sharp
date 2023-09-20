using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using QuickType;

namespace ApiTest
{
    class Program
    {
        static async Task Main(string[] args)
        {   // acessa o link da url da api
            HttpClient client = new HttpClient{ BaseAddress = new Uri("https://jsonplaceholder.typicode.com/users") };

            // armazena o retorno da url da api users
            var response = await client.GetAsync("users");

            // o retorno armazenado é lido como string
            var content = await response.Content.ReadAsStringAsync();

            // ocorre a conversão do dado armazenado para json
            var users = JsonConvert.DeserializeObject<User[]>(content);              

            
            Console.WriteLine(users);

            // retorna nomes e emails da api
            foreach (var item in users)
            {
                Console.WriteLine(item.Name);

                Console.WriteLine(item.Email);
            }
        }
    }
}





