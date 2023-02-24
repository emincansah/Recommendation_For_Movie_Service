using RabbitMQ.Client;
using System.Text;

namespace RabbitMqClient
{
    public class QueueCliet
    {

        public void RabbitMqSendemail(string request)
        {
            var factory = new ConnectionFactory()
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

                    var body = Encoding.UTF8.GetBytes(request);

                    channel.BasicPublish(exchange: "",
                                                         routingKey: "mailqueue",
                                                         basicProperties: null,
                                                         body: body);
                };

            };


        }
    }
    }