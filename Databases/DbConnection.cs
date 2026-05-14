using Npgsql;

namespace notificationsystem.Databases;

public class DbConnection
{
    private readonly string connection = "host=localhost;Port=5432;Username=murasaki;Password=123456;Database=notificationdb";
    
    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(connection);
    }
}

