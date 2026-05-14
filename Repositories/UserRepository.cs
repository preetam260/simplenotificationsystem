using Npgsql;
using notificationsystem.Databases;
using notificationsystem.Models;

namespace notificationsystem.Repositories;

public class UserRepository
{
    DbConnection dbConnection = new DbConnection();

        public void AddUser(User user)
        {
            using NpgsqlConnection conn = dbConnection.GetConnection();
            conn.Open();
            string query = $"insert into users (username, email, number) values ('{user.Username}', '{user.Email}', '{user.Number}')";
            using NpgsqlCommand command = new NpgsqlCommand(query, conn);  

            command.ExecuteNonQuery();     
        }

        public List<User> GetUsers() {
            List<User> users = new List<User>();

            using NpgsqlConnection conn = dbConnection.GetConnection();
            conn.Open();    

            string query = "SELECT * FROM users";
            using NpgsqlCommand command = new NpgsqlCommand(query, conn);
            using NpgsqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                var user = new User(
                    dataReader["username"].ToString()!,
                    dataReader["email"].ToString()!,
                    dataReader["number"].ToString()!
                );
                if (int.TryParse(dataReader["id"].ToString(), out var id))
                    user.Id = id;
                users.Add(user);
            }
            return users;               
        }
}