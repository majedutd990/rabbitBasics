// See https://aka.ms/new-console-template for more information

using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory
{
    HostName = "localhost",
    UserName = "guest",
    Password = "guest"
};
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
channel.QueueDeclare(
    "letterbox",
    false,
    false,
    false,
    null);
var message = "This is my first message";
var encodedMessage = Encoding.UTF8.GetBytes(message);
channel.BasicPublish("", "letterbox", null, encodedMessage);
Console.WriteLine("We published a Message: {0}", message);