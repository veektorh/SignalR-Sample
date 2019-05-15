using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Hubs
{
    public class ChatHub : Hub
    {

        public override async Task OnConnectedAsync()
        {
            var connId = Context.ConnectionId;
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string user, string message)
        {
            //Emits ReceiveMessage event
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task AnotherMethod(string user, string message)
        {
            //Emits ReceiveMessage event
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }


    }
}
