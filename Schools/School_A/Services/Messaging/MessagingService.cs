using System.Collections.Concurrent;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace School.Services
{
    public class MessagingService : IMessagingService
    {
        // private IMessagingService _messagingService;
        private IModel channel;
        private IConnectionFactory factory;
        private IConnection connection;
        private readonly ConcurrentDictionary<string, TaskCompletionSource<string>> callbackMapper =
        new();

        public MessagingService()
        {
            // _messagingService = messagingService;

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

            channel.QueueDeclare(
                queue: "Response",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                if (!callbackMapper.TryRemove(ea.BasicProperties.CorrelationId, out var tcs))
                    return;
                var body = ea.Body.ToArray();
                var response = Encoding.UTF8.GetString(body);
                tcs.TrySetResult(response);
            };
            channel.BasicConsume(consumer: consumer, queue: "Response", autoAck: true);
        }

        public Task<string> SendMessage(string student, CancellationToken cancellationToken = default)
        {
            IBasicProperties props = channel.CreateBasicProperties();
            var correlationId = Guid.NewGuid().ToString();
            props.CorrelationId = correlationId;
            props.ReplyTo = "Response";
            var message = student;
            var body = Encoding.UTF8.GetBytes(message);
            var tcs = new TaskCompletionSource<string>();
            callbackMapper.TryAdd(correlationId, tcs);
            channel.BasicPublish(
                exchange: "",
                routingKey: "Common",
                basicProperties: props,
                body: body
            );

            cancellationToken.Register(() => callbackMapper.TryRemove(correlationId, out _));
            return tcs.Task;
        }

        // public async Task<bool> ReceiveMessage()
        // {
        //     channel = connection.CreateModel();
        //     channel.QueueDeclare(
        //         queue: "Response",
        //         durable: false,
        //         exclusive: false,
        //         autoDelete: false,
        //         arguments: null
        //     );
        //     channel.BasicQos(prefetchSize: 0, prefetchCount: 0, global: false);

        //     var consumer = new EventingBasicConsumer(channel);
        //     consumer.Received += (model, ea) =>
        //     {
        //         var body = ea.Body.ToArray();
        //         var message = Encoding.UTF8.GetString(body);
        //         if (message == "Internal server occured")
        //         {
        //             throw new Exception("Internal error occured at education board");
        //         }
        //     };
        //     channel.BasicConsume(queue: "Response", autoAck: true, consumer: consumer);
        //     return true;
        // }
    }
}
