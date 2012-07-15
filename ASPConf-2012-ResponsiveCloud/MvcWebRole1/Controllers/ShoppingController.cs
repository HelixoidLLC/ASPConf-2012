using System.Diagnostics;
using System.Web.Http;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MvcWebRole1.Controllers
{
    public class ShoppingController : ApiController
    {
        public void Post(ShoppingItem item)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("QueueConnectionString"));
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("buy-queue");
            queue.CreateIfNotExist();

            var endPoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["MainEndpoint"].IPEndpoint;
            string ip = endPoint.Address.ToString();
            int port = endPoint.Port;

            var msg = JObject.FromObject(item);
            msg["Address"] = ip + ":" + port;
            var message = new CloudQueueMessage(msg.ToString(Formatting.None));
            queue.AddMessage(message);

            Trace.WriteLine("Ordering: " + msg, "Information");
        }
    }

    public class ShoppingItem
    {
        public string Name { get; set; }
    }
}
