using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MidasChatApi.Interfaces;

namespace MidasChatApi.Services
{
    public class ChatDBServices : IMidasSettings
    {
        public string ConnectionString { get ; set; }
        public string DatabaseName { get ; set ; }
        public string ChatCollection { get ; set ; }
    }
}
