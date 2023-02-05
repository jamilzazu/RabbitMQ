using System.Text;
using System.Text.Json;
using Airline.Core.RabbitMQ;
using RabbitMQ.Client;

namespace Airline.API.Services;

public class MessageProducer : IMessageProducer
{
    private const string _queueName = "bookings";
    private const string exchange = "";

    public void SendingMessage<T>(T message, string queueName)
    {
        var channel = Connection.GetChannel();
        BuildQueue(channel, queueName);
        ChannelBasicPublish(channel, BuildBody(message));
        WriteConsole(message);
    }

    private static void BuildQueue(IModel channel, string queueName)
    {
        Queue.GetQueue(channel, queueName, true, false, false);
    }

    private static byte[] BuildBody<T>(T message)
    {
        var jsonString = JsonSerializer.Serialize(message);
        return Encoding.UTF8.GetBytes(jsonString);
    }

    private static void ChannelBasicPublish(IModel channel, byte[] body)
    {
        channel.BasicPublish(exchange, _queueName, body: body);
    }

    private static void WriteConsole<T>(T message)
    {
        Console.WriteLine(" [x] Sent {0}", JsonSerializer.Serialize(message));
    }
}