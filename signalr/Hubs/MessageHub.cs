using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;


namespace signalr.Hubs {
    public class MessageHub: Hub{
        public Task SendMessageToAll(string message){
            return Clients.All.SendAsync("RecieveMessage",message);
        }

    }
}