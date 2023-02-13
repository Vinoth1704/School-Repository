using System.Collections.Concurrent;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace School.Services
{
    public class MessagingService : IMessagingService
    {
        private const string _queueName = "Common";
        private IModel channel;
        private IConnectionFactory factory;
        private IConnection connection;
        private readonly string replyQueueName = "Response";
        private readonly ConcurrentDictionary<string, TaskCompletionSource<string>> callbackMapper = new();

        public MessagingService()
        {
            factory = new ConnectionFactory() { HostName = "localHost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();

            //Declaring the Queue with the name of Response
            channel.QueueDeclare(
                queue: replyQueueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            //Receiver function
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                if (!callbackMapper.TryRemove(ea.BasicProperties.CorrelationId, out var tcs))
                    return;
                var body = ea.Body.ToArray();
                var response = Encoding.UTF8.GetString(body);
                tcs.TrySetResult(response);
                Console.WriteLine(response);
                if (response == "Internal error occured")
                {
                    throw new Exception("Failed to update in Education Board");
                }
            };
            channel.BasicConsume(consumer: consumer, queue: replyQueueName, autoAck: true);
        }

        public Task<string> SendMessage(string student, CancellationToken cancellationToken = default)
        {
            IBasicProperties props = channel.CreateBasicProperties();
            var correlationId = Guid.NewGuid().ToString();
            props.CorrelationId = correlationId;
            props.ReplyTo = replyQueueName;
            var tcs = new TaskCompletionSource<string>();
            callbackMapper.TryAdd(correlationId, tcs);
            var message = student;
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(
                exchange: "",
                routingKey: _queueName,
                basicProperties: props,
                body: body
            );
            cancellationToken.Register(() => callbackMapper.TryRemove(correlationId, out _));
            Console.WriteLine(tcs.Task);
            return tcs.Task;
        }
    }
}
