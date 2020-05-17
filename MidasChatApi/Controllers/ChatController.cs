using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MidasChatApi.Models;
using MidasChatApi.Services;
using Microsoft.AspNetCore.SignalR;
using MidasChatApi.Interfaces;

namespace MidasChatApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IHubContext<ChatHub> _hubContext;

        private readonly ChatServices _chatServices;
        public ChatController(IHubContext<ChatHub> hubContext, ChatServices chatServices)
        {
            _hubContext = hubContext;
            _chatServices = chatServices;
        }

        //To test the api.
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string user, string message)
        {
            ChatModel objChat = new ChatModel();
            objChat.UserName = user;
            objChat.SendMessage = message;
            objChat.DateModified = DateTime.Now;

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);

            _chatServices.AddChat(objChat);
            return Ok(objChat);  
        }
    }
}