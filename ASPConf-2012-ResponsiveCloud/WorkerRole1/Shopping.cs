using System.Diagnostics;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using Newtonsoft.Json.Linq;
using SignalR.Client.Hubs;

namespace WorkerRole1
{
    public static class Shopping
    {
        public static void Process()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("QueueConnectionString"));
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("buy-queue");
            queue.CreateIfNotExist();

            CloudQueueMessage retrievedMessage = queue.GetMessage();

            if (retrievedMessage != null)
            {
                var item = JObject.Parse(retrievedMessage.AsString);

                Trace.WriteLine("Ordered: " + item["Name"], "Information");

                var message = "Processed: " + item["Name"];
                var instance = RoleEnvironment.CurrentRoleInstance.Role.Instances[0].Id;

                var connection = new HubConnection("http://" + item["Address"] + "/");
                connection.Start().ContinueWith(t =>
                    {
                        var processHub = connection.CreateProxy("MessagingHub");

                        processHub.Invoke("Processed", message, instance);
                    });

                queue.DeleteMessage(retrievedMessage);
            }
        }
    }
}