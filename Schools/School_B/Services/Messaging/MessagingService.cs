using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using School.Models;

namespace School.Services
{
    public class MessagingService : IMessagingService
    {
        public void SendMessage(string student)
        {
            var factory = new ConnectionFactory() { HostName = "localHost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "School", type: ExchangeType.Direct);
            var message = student;
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "School",
                                routingKey: "Common",
                                basicProperties: null,
                                body: body);
        }

        public bool ReceiveMessage()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "School", ExchangeType.Direct);
            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName, exchange: "School", routingKey: "Response");


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
            return true;
        }

    }

}