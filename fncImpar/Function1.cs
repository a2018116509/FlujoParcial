namespace fncImpar
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task RunAsync([ServiceBusTrigger(
                "qimpar", 
                Connection = "MyConn"
                )]string myQueueItem,
            [CosmosDB(
                databaseName: "dbImpar",
                collectionName: "Impares",
                ConnectionStringSetting = "strCosmos"
                )]IAsyncCollector<object> datos,
            ILogger log)
        {
            try
            {
                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                var dataRandom = JsonConvert.DeserializeObject<Random>(myQueueItem);
                await datos.AddAsync(dataRandom);
            }
            catch(Exception ex) 
            {
                log.LogError($"No fue posible insertar datos: {ex.Message}");
            }
        }
    }
}
