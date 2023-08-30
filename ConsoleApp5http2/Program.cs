using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5http2
{
    class Program
    {
        HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.GetTodosItems();

        }

        private async Task GetTodosItems()
        {
            string response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/todos");
            Console.WriteLine(response);

            List<Todo>  todo = JsonConvert.DeserializeObject<List<Todo>>(response);
            foreach (Todo item in todo)
            {
                Console.WriteLine($"{item.UserId} \t{item.Id} \t{item.Title} \t{item.Completed} "  );
            }
            Console.ReadLine();
        }
    }

    class Todo
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Completed { get; set; }
    }
}
