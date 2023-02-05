using System.Reflection;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace Airline.Core.RabbitMQ;

public static class Connection
{
    private static string? _hostName;
    private static string? _userName;
    private static string? _password;
    private static string? _virtualHost;

    private static IConnection? _connection;
    private static IModel? _channel;

    public static IModel GetChannel()
    {
        if (_connection is { IsOpen: true }) return _channel!;
        CreateConnection();
        return _channel!;
    }

    private static void GetValuesFromAppSettings()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var projectAirlinePath = currentDirectory.Split("Airline.")[0];
        var appSettingsPath = Path.Combine(projectAirlinePath, "Airline.API/appsettings.Development.json");

        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!)
            .AddJsonFile(appSettingsPath);

        var config = builder.Build();

        _hostName = config.GetValue<string>("RabbitMQ:HostName");
        _userName = config.GetValue<string>("RabbitMQ:UserName");
        _password = config.GetValue<string>("RabbitMQ:Password");
        _virtualHost = config.GetValue<string>("RabbitMQ:VirtualHost");
    }

    private static void CreateConnection()
    {
        GetValuesFromAppSettings();

        var factory = new ConnectionFactory
        {
            HostName = _hostName,
            UserName = _userName,
            Password = _password,
            VirtualHost = _virtualHost
        };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }
}