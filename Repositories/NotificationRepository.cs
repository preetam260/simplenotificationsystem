using notificationsystem.Databases;
using notificationsystem.Models;
using Npgsql;

namespace notificationsystem.Repositories;

public class NotificationRepository
{
    DbConnection dbConnection = new DbConnection();

        public void AddNotification(Notification notification)
        {
            using NpgsqlConnection conn = dbConnection.GetConnection();
            conn.Open();
            string query = $"INSERT INTO notifications (userid, message, notificationtype) VALUES ({notification.Userid}, '{notification.Message}', '{notification.NotificationType}')";
            using NpgsqlCommand command = new NpgsqlCommand(query, conn);  

            command.ExecuteNonQuery();     
        }

        public List<string> GetNotificationHistory() {
            List<string> notificationHistory = new List<string>();

            using NpgsqlConnection conn = dbConnection.GetConnection();
            conn.Open();    

            string query = "SELECT u.username, n.message, n.notificationtype, n.sentat FROM users u JOIN notifications n ON n.userid = u.id";
            using NpgsqlCommand command = new NpgsqlCommand(query, conn);
            using NpgsqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                string history = $"User: {dataReader["username"]} - Message: {dataReader["message"]} - Type: {dataReader["notificationtype"]} - Sent: {dataReader["sentat"]}";
                notificationHistory.Add(history);
            }
            return notificationHistory;               
        }
}