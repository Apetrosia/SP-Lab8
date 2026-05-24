using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace GreenSwampApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string userIcon, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, userIcon, message);
        }
    }
}