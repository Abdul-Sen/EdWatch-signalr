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

        // <summary>
        //  Adds the host user to the specified group
        // </summary>
        public Task CreateGroup(string groupName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId,groupName);
        }

        // <summary>
        //  Adds the current user to the specified group
        // </summary>
        /// <param name="groupName">Used to add to that group.</param>
        /// <param name="userName">Used alert others about the new user added.</param>
        public Task AddCurrentUserToGroup(string groupName, string userName)
        {
            Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            Clients.OthersInGroup(groupName).SendAsync("GetHostVideo");

            string alertBuilder = userName + " has joined!";
            return NewGroupAlert(groupName,alertBuilder);
        }

        // <summary>
        // <para> Sends an alert to the group using a bot
        // <summary
        public Task NewGroupAlert(string groupName, string alert)
        {
           return Clients.Group(groupName).SendAsync("GroupAlert", alert);
        }

        // <summary>
        //  <para>Sends message to all in a specified group except self</para>
        // </summary>
        /// <param name="groupName">Used scope the group this payload is intended for.</param>
        /// <param name="messagePayload">The message we want to send to other users</param>
        public Task NewGroupMessage(string messagePayload, string groupName)
        {
            return Clients.OthersInGroup(groupName).SendAsync("ReciveNewMessage", messagePayload);
        }

        // <summary>
        //  Removes current user from the specified group
        // </summary>
        public Task RemoveUserFromGroup(string groupName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
//---------------------------------------------------------VIDEO CALLS--------
        public Task SetGroupVideo(string url, string groupName)
        {
           return Clients.OthersInGroup(groupName).SendAsync("LoadGroupVideo",url);
        }

        public Task UpdateGroupVideoState(string videoState, string groupName)
        {
            Console.WriteLine(videoState);
            return Clients.OthersInGroup(groupName).SendAsync("NewVideoState", videoState);
        }
    }
}