using Airline.Core.RabbitMQ;
using RabbitMQ.Client;

namespace Airline.Ticket.Processing;

public static class ReceiveMessage
{
    public static void GetMessages(string queueName)
    {
        var channel = Connection.GetChannel();
        BuildQueue(channel, queueName);
        var consumer = Consumer.GetConsumer(channel);
        
        ChannelBasicConsume(channel, queueName, true, consumer);
    }

    private static void BuildQueue(IModel channel, string queueName)
    {
        Queue.GetQueue(channel, queueName, true, false, false);
    }

    private static void ChannelBasicConsume(IModel channel, string queueName, bool autoAck,
        IBasicConsumer consumer)
    {
        channel.BasicConsume(queue: queueName, autoAck: autoAck, consumer: consumer);
        WriteConsole();
    }

    private static void WriteConsole()
    {
        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}