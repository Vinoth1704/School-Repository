using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using EducationBoard.Models;
using Newtonsoft.Json.Linq;

namespace EducationBoard.Services
{
    public class MessagingService : IMessagingService
    {
        private IStudentService _studentService;
        private IPerformanceService _performanceService;

        public MessagingService(IStudentService studentService, IPerformanceService performanceService)
        {
            _studentService = studentService;
            _performanceService = performanceService;
        }
        public void checkMessage()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "School", ExchangeType.Direct);
            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName, exchange: "School", routingKey: "Common");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var json = JObject.Parse(message);
                string Function = (string)json["Function"]!;
                if (Function == "Create Student")
                {
                    var data = JsonConvert.DeserializeObject<Student>(message)!;
                    _studentService.CreateStudent(data);
                }
                else if (Function == "Added Score")
                {
                    var data = JsonConvert.DeserializeObject<Performance>(message)!;
                    _performanceService.InsertMark(data);
                }

            };

            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        }
    }
}