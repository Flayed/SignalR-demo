using Microsoft.AspNet.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace EnvironmentStatusViewer
{
    public class Client
    {
        private readonly HubConnection HubConnection;
        private IHubProxy HubProxy;
        private const string HOST_URL = "http://localhost:8616";
        public Client()
        {
            HubConnection = new HubConnection(HOST_URL);
        }

        public async Task Start(Action<string, string> UpdateEnvironmentStatus)
        {
            HubProxy = HubConnection.CreateHubProxy("EnvironmentStatusHub");
            HubProxy.On("UpdateEnvironment", UpdateEnvironmentStatus);
            await HubConnection.Start();
        }
    }
}
