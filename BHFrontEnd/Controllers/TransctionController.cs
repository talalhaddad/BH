using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using BHFrontEnd.Data;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BHFrontEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransctionController : ControllerBase
    {
        private IConfiguration _configuration;
        private ApplicationDbContext _context;

        public TransctionController(IConfiguration configuration, ApplicationDbContext applicationDbContext)
        {
            _configuration = configuration;
            _context = applicationDbContext;
        }
        // POST api/<TransctionController>
        [HttpPost]
        public async Task PostAsync([FromBody] Transaction transaction)
        {
            try
            {
                
                string serviceBusConnectionString = _configuration.GetConnectionString("SBConnectionString");
               
                ServiceBusClient client;
                ServiceBusSender sender;
                var clientOptions = new ServiceBusClientOptions()
                {
                    TransportType = ServiceBusTransportType.AmqpWebSockets
                };
                client = new ServiceBusClient(serviceBusConnectionString, clientOptions);
                sender = client.CreateSender("transactions");
                ServiceBusMessage message = new ServiceBusMessage(JsonSerializer.Serialize(transaction));
                await sender.SendMessageAsync(message);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
    public class Transaction
    {
        public Guid UserId { get; set; }
        public decimal Credit { get; set; }
    }
}
