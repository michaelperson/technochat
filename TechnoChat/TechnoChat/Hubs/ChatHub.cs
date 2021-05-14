using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoChat.Hubs.Interfaces;

namespace TechnoChat.Hubs
{
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
            throw new NotImplementedException();
        }

        public async Task Wizz(string recipient = "Tous", string groupName = "Aucun")
        {
            throw new NotImplementedException();
        }
    }
}
