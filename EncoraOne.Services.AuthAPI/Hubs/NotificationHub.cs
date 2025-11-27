using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EncoraOne.Grievance.API.Hubs
{
    // This class acts as the bridge for real-time communication
    public class NotificationHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}