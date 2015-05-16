using Microsoft.Owin.Hosting;
using Owin;
using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:8616";

            using (WebApp.Start(url))
            {
                
                Console.Title = $"Server running on {url}.  Press [ESC] to exit";
                ConsoleKeyInfo cki = new ConsoleKeyInfo();
                while (cki.Key != ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.WriteLine("Pick an environment: ");
                    var env = GetInput("Dev", "Test", "Stage");
                    Console.WriteLine("Pick a status: ");
                    var status = GetInput("Good", "Progress", "Broken");
                    Console.WriteLine($"Setting {env} to {status}.");
                    EnvironmentStatusHubAccessor.UpdateEnvironment(env, status);
                    Console.WriteLine("Press any key to continue.");
                    cki = Console.ReadKey();  
                }                
            }
        }

        static string GetInput(params string[] choices)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            for (int idx = 0; idx < choices.Length; idx++)
                Console.WriteLine($"\t{idx + 1}: {choices[idx]}");
            while (!(cki.Key >= ConsoleKey.D1 && cki.Key < (ConsoleKey.D1 + choices.Length))) cki = Console.ReadKey(true);
            return choices[cki.Key - (ConsoleKey.D1)];
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
