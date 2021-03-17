namespace apiDoble.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using Azure.Messaging.ServiceBus;
    using Newtonsoft.Json;
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        [HttpPost]
        public async Task<bool> EnviarAsync([FromBody] Random random)
        {
            string connectionString = "Endpoint=sb://queueparcial.servicebus.windows.net/;SharedAccessKeyName=enviar;SharedAccessKey=98Aa0O+bk23JEi8KCSygzFjxB9ER/MBii1DESCN9+fU=;EntityPath=qimpar";
            string queueName = "qimpar";
            String mensaje = JsonConvert.SerializeObject(random);

            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                // create a sender for the queue 
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(mensaje);

                // send the message
                await sender.SendMessageAsync(message);
                Console.WriteLine($"Sent a single message to the queue: {queueName}");
            }

            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                // create a sender for the queue 
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(mensaje);

                // send the message
                await sender.SendMessageAsync(message);
                Console.WriteLine($"Sent a single message to the queue: {queueName}");
            }

            return true;
        }

    }
}
