using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;

namespace Server
{
    public class EnvironmentStatusHub : Hub
    {
        public override Task OnConnected()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"*** Client {Context.ConnectionId} connected.");
            Console.ForegroundColor = ConsoleColor.White;
            return base.OnConnected();
        }
    }

    public static class EnvironmentStatusHubAccessor
    {
        private static IHubContext Context
        {
            get
            {
                return GlobalHost.ConnectionManager.GetHubContext<EnvironmentStatusHub>();
            }
        }

        public static void UpdateEnvironment(string environment, string status)
        {
            Context.Clients.All.UpdateEnvironment(environment, status);
        }
    }
}
