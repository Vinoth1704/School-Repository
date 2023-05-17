// using System.Text;
// using Newtonsoft.Json;
// using RabbitMQ.Client;
// using RabbitMQ.Client.Events;
// using EducationBoard.Models;
// using EducationBoard.Controllers;
// using Newtonsoft.Json.Linq;

// namespace EducationBoard.Services
// {
//     public class MessagingService : IMessagingService
//     {
//         private IStudentService _studentService;
//         private StudentController _studentController;
//         private IPerformanceService _performanceService;

//         public MessagingService(IStudentService studentService, IPerformanceService performanceService, StudentController studentController)
//         {
//             _studentService = studentService;
//             _performanceService = performanceService;
//             _studentController = studentController;
//         }

//         public void checkMessage()
//         {
//             var factory = new ConnectionFactory() { HostName = "localhost" };
//             var connection = factory.CreateConnection();
//             var channel = connection.CreateModel();

//             channel.QueueDeclare(
//                 queue: "Common",
//                 durable: false,
//                 exclusive: false,
//                 autoDelete: false,
//                 arguments: null
//             );
//             channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

//             var consumer = new EventingBasicConsumer(channel);
//             channel.BasicConsume(queue: "Common", autoAck: true, consumer: consumer);
//             consumer.Received += (model, ea) =>
//             {
//                 var body = ea.Body.ToArray();
//                 string response = string.Empty;

//                 var props = ea.BasicProperties;
//                 var replyProps = channel.CreateBasicProperties();
//                 replyProps.CorrelationId = props.CorrelationId;

//                 var message = Encoding.UTF8.GetString(body);
//                 var json = JObject.Parse(message);
//                 string Function = (string)json["Function"]!;
//                 if (Function == "Create Student")
//                 {
//                     var data = JsonConvert.DeserializeObject<Student>(message)!;
//                     if (_studentService.CreateStudent(data))
//                     {
//                         response = "Student Created successfully";
//                     }
//                     else
//                     {
//                         response = "Internal error occured";
//                     }
//                     Console.WriteLine(response);
//                     var responseBytes = Encoding.UTF8.GetBytes(response);
//                     channel.BasicPublish(
//                         exchange: string.Empty,
//                         routingKey: props.ReplyTo,
//                         basicProperties: replyProps,
//                         body: responseBytes
//                     );
//                     // channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
//                 }
//                 else if (Function == "Added Score")
//                 {
//                     var data = JsonConvert.DeserializeObject<Performance>(message)!;
//                     _performanceService.InsertMark(data);
//                 }
//             };


//         }


//     }
// }
