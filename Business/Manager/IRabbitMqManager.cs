using Business.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class IRabbitMqManager: IRabbitMqService
    {
        public void SendMail<T>(T entity)
        {var factory = new ConnectionFactory()
            {
                HostName = "rabbit_url",
                Port = 5672,
                UserName = "admin",
                Password = "admin"
            };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("mailqueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    var json = JsonConvert.SerializeObject(entity);
                    var body = Encoding.UTF8.GetBytes(json);
                    

                    channel.BasicPublish(exchange: "",
                                                         routingKey: "mailqueue",
                                                         basicProperties: null,
                                                         body: body);
                };

            };
            
        }
    }
}
