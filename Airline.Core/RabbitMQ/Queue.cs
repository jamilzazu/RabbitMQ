using RabbitMQ.Client;

namespace Airline.Core.RabbitMQ;

public static class Queue
{
    public static void GetQueue(IModel channel, string queueName, bool durable, bool exclusive, bool autoDelete,
        IDictionary<string, object> arguments = null)
    {
        CreateQueue(channel, queueName, durable, exclusive, autoDelete, arguments);
    }

    private static void CreateQueue(IModel channel, string queueName, bool durable, bool exclusive, bool autoDelete,
        IDictionary<string, object> arguments)
    {
        channel.QueueDeclare(queue: queueName,
            durable: durable,
            exclusive: exclusive,
            autoDelete: autoDelete,
            arguments: arguments);
    }
}