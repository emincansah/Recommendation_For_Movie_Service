using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqCunsomer;
using System.Text;

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

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (sender, e) =>
        {
            var body = e.Body.ToArray();
            var requestBody = Encoding.UTF8.GetString(body);
            EmailSending eMailSending = new EmailSending();      
           await eMailSending.sendmail(requestBody);
           ;

        };

        channel.BasicConsume("MailSending", true, consumer);
        Console.ReadLine();
    }
}