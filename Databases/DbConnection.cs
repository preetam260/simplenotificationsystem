using Npgsql;

namespace notificationsystem.Databases;

public class DbConnection
{
    private readonly string connection = "host=localhost;Port=5432;Username=yourusername;Password=yourpassword;Database=notificationdb";
    
    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(connection);
    }
}

