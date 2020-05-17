using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using MidasChatApi.Models;
using MidasChatApi.Interfaces;
using System.Diagnostics;

namespace MidasChatApi.Services
{
    public class ChatHub : Hub    
    {
        private readonly ChatServices _chatServices;
        public ChatHub(ChatServices chatServices)
        {
            _chatServices = chatServices;
        }

        public override Task OnConnectedAsync()
        {
            Debug.WriteLine(Context.ConnectionId);
            return base.OnConnectedAsync();
        }
        public async Task JoinChat(string user)
        {
            await Clients.All.SendAsync("JoinChat", user);
        }

        public async Task LeaveChat(string user)
        {
            await Clients.All.SendAsync("LeaveChat", user);
        }

        public async Task SendMessage(string user, string message)
        {
            ChatModel objChat = new ChatModel();
            objChat.UserName = user;
            objChat.SendMessage = message;
            objChat.DateModified = DateTime.Now;

            await  Clients.All.SendAsync("ReceiveMessage", user, message);
            _chatServices.AddChat(objChat);

        }

    }
}
