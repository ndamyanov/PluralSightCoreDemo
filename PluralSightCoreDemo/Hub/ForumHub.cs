using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace PluralSightCoreDemo.Hub
{
    public class ForumHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public async Task Send(string message)
        {
            await this.Clients.All.InvokeAsync("Send", message);
            
        }
    }
}
