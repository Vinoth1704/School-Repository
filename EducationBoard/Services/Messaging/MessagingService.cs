using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using EducationBoard.Models;
using EducationBoard.Controllers;
using Newtonsoft.Json.Linq;

namespace EducationBoard.Services
{
    public class MessagingService : IMessagingService
    {
        private IStudentService _studentService;
        private StudentController _studentController;
        private IPerformanceService _performanceService;

        public MessagingService(
            IStudentService studentService,
            IPerformanceService performanceService,
            StudentController studentController
        )
        {
            _studentService = studentService;
            _performanceService = performanceService;
            _studentController = studentController;
        }

        public void checkMessage()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "Common",
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
                var json = JObject.Parse(message);
                string Function = (string)json["Function"]!;
                if (Function == "Create Student")
                {
                    var data = JsonConvert.DeserializeObject<Student>(message)!;
                    if (_studentService.CreateStudent(data))
                    {
                        MessagingService.SendMessage("Student Created successfully");
                    }
                    else
                    {
                        MessagingService.SendMessage("Internal server occured");
                    }
                }
                else if (Function == "Added Score")
                {
                    var data = JsonConvert.DeserializeObject<Performance>(message)!;
                    _performanceService.InsertMark(data);
                }
            };

            channel.BasicConsume(queue: "Common", autoAck: true, consumer: consumer);
        }

        public static void SendMessage(string student)
        {
            var factory = new ConnectionFactory() { HostName = "localHost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            // channel.ExchangeDeclare(exchange: "School", type: ExchangeType.Direct);
            channel.QueueDeclare(
                queue: "Response",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );
            var message = student;
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(
                exchange: "",
                routingKey: "Response",
                basicProperties: null,
                body: body
            );
        }
    }
}
