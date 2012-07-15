using SignalR.Hubs;

namespace MvcWebRole1.Hubs
{
    public class MessagingHub : Hub
    {
         public void Processed(string message, string instance)
         {
             Clients.itemProcessed(message, instance);
         }
    }
}