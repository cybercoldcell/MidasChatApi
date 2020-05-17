using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidasChatApi.Interfaces
{
    public interface IMidasSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

        string ChatCollection { get; set; }
      
    }
}
