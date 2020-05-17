using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MidasChatApi.Models;
using MidasChatApi.Interfaces;

namespace MidasChatApi.Services
{
    public class ChatServices 
    {
        private IMongoCollection<ChatModel> _chat;
        
        public ChatServices(IMidasSettings setting)
        {

            var client = new MongoClient(setting.ConnectionString);
            var db = client.GetDatabase(setting.DatabaseName);

            _chat = db.GetCollection<ChatModel>(setting.ChatCollection);

        }

        public ChatModel AddChat(ChatModel objChat)
        {
            _chat.InsertOne(objChat);
            return objChat;
        }

    }
}
