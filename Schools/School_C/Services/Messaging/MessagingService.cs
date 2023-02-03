using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using School.Models;

namespace School.Services
{
    public class MessagingService : IMessagingService
    {
        private IModel channel;
        private IConnectionFactory factory;
        private IConnection connection;

        public MessagingService()
        {
            factory = new ConnectionFactory() { HostName = "localHost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(
                queue: "Common",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );
        }

        public void SendMessage(string student)
        {
            var message = student;
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(
                exchange: "",
                routingKey: "Common",
                basicProperties: null,
                body: body
            );
        }

        public  bool ReceiveMessage()
        {
            channel = connection.CreateModel();
            channel.QueueDeclare(
                queue: "Response",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );
            channel.BasicQos(prefetchSize: 0, prefetchCount: 0, global: false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                if (message == "Internal server occured")
                {
                    throw new Exception("Internal error occured at education board");
                }
            };
            channel.BasicConsume(queue: "Response", autoAck: true, consumer: consumer);
            return true;
        }
    }
}
