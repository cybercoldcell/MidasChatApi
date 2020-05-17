using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidasChatApi.Models
{
    public class ChatModel
    {
        public string UserName { get; set; }
        public string SendMessage { get; set; }

        public DateTime DateModified { get; set; }
    }
}
