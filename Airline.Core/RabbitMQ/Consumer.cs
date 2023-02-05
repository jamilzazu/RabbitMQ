using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Airline.Core.RabbitMQ;

public static class Consumer
{
    public static EventingBasicConsumer GetConsumer(IModel channel)
    {
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (_, ea) =>
        {
            var body = ea.Body.ToArray();
            WriteConsole(Encoding.UTF8.GetString(body));
        };

        return consumer;
    }

    private static void WriteConsole(string message)
    {
        Console.WriteLine(" [x] Received {0}", message);
    }
}