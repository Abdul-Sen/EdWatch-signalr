using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System;

namespace signalr.Hubs
{
    public class MessageHub : Hub
    {
        public Task SendMessageToAll(string message)
        {
            Console.WriteLine("Invoked sendmessagetoall");
            Console.WriteLine(Context.ConnectionId);
            return Clients.All.SendAsync("RecieveMessage", message);
        }
        public Task NewMessageToAll(string payload)
        {
            return Clients.AllExcept(Context.ConnectionId).SendAsync("ReciveNewMessage", payload);
        }
    }
}