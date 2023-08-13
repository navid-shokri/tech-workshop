using RabbitMQ.Client;

namespace MessageBroker;

public class Publisher
{
    private IConnection _connection;
    private IModel _channel; 
    public Publisher(IConnectionFactory connectionFactory)
    {
        _connection = connectionFactory.CreateConnection();
    }

    //public void CreateChannel("");
}