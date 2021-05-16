using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoChat.Hubs.Interfaces;

namespace TechnoChat.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ChatHub : Hub<IChatClient>, IChatHub
    {
        public async Task ChangeStatus(EStatus status)
        {
            throw new NotImplementedException();
        }

        public async Task MemberJoinGroup(string groupName)
        {
            throw new NotImplementedException();
        }

        public async Task MemberLeaveGroup(string groupName)
        {
            throw new NotImplementedException();
        }

        public async Task SendMessage(string message, string recipient = "Tous", string groupName = "Aucun")
        {
           if(recipient != "Tous")
            {
                await Clients.Client(recipient).ReceiveMessage(message, Context.ConnectionId); 
            }
           else if (groupName != "Aucun")
            {
                await Clients.Group(groupName).ReceiveMessage(message, Context.ConnectionId);
            }
             else
            {
                await Clients.AllExcept(Context.ConnectionId).ReceiveMessage(message, Context.ConnectionId);
            }
        }

        public async Task Wizz(string recipient = "Tous", string groupName = "Aucun")
        {
            throw new NotImplementedException();
        }


        public override Task OnConnectedAsync()
        {
            Clients.AllExcept(Context.ConnectionId).ReceiveMessage($"{Context.ConnectionId} join the TechnoChat", Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.AllExcept(Context.ConnectionId).ReceiveMessage($"{Context.ConnectionId} has leaved the TechnoChat", Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
