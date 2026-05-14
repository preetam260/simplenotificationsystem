using notificationsystem.Databases;
using notificationsystem.Models;
using Npgsql;
using notificationsystem.Repositories;
using notificationsystem.Interfaces;
using notificationsystem.Services;

namespace notificationsystem;

class Program
{
    static void Main(string[] args)
    {
        UserRepository userRepository = new UserRepository();
        NotificationServices notificationServices = new NotificationServices();

        System.Console.WriteLine("Enter a number 1: add user, 2: view users, 3: send notification, 4: notification history");
        string choice = Console.ReadLine()!;

        switch (choice)
        {
            case "1":
                //details for the user
                System.Console.WriteLine("Enter username:");
                string username = Console.ReadLine()!;
                System.Console.WriteLine("Enter email:");
                string email = Console.ReadLine()!;
                System.Console.WriteLine("Enter number:");
                string number = Console.ReadLine()!;

                //create user
                userRepository.AddUser(new User(username, email, number));
                break;

            case "2":
                //view all users
                List<User> users = userRepository.GetUsers();
                foreach (User userr in users)
                {
                    System.Console.WriteLine($"UserId: {userr.Id},Username: {userr.Username}, Email: {userr.Email}, Number: {userr.Number}");
                }
                break;

            case "3":
                //send a new notification

                Notification notification = new Notification();

                //details for the notification
                System.Console.WriteLine("Enter user id:");
                notification.Userid = int.Parse(Console.ReadLine()!);
                // find user by id
                User user = userRepository.GetUsers().FirstOrDefault(u => u.Id == notification.Userid)!;

                System.Console.WriteLine("Enter message:");
                notification.Message = Console.ReadLine()!;
                System.Console.WriteLine("Enter notification type (email/sms):");
                notification.NotificationType = Console.ReadLine()!;

                notificationServices.SendNotification(user, notification);
                break;

            case "4":
                //view notification history
                List<string> notificationHistory = notificationServices.GetNotificationHistory();
                foreach (string history in notificationHistory)
                {
                    System.Console.WriteLine(history);
                }
                break;
        }
    }
}

