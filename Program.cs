using System;

public class Program
{
    public static void Main(string[] args)
    {
        var userRepository = new UserRepository();

        var notificationRepository =
            new NotificationRepository();

        var service = new NotificationService(
            userRepository,
            notificationRepository);

        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. View Users");
            Console.WriteLine("3. Send Email Notification");
            Console.WriteLine("4. Send SMS Notification");
            Console.WriteLine("5. View Notifications");
            Console.WriteLine("6. Delete Notification");
            Console.WriteLine("7. Exit");
            Console.WriteLine();

            Console.Write("Enter Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter User Id: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine() ?? string.Empty;

                    Console.Write("Enter Email: ");
                    string email = Console.ReadLine() ?? string.Empty;

                    Console.Write("Enter Number: ");
                    string number = Console.ReadLine() ?? string.Empty;

                    var user = new User {Id = id, Name = name, Email = email, Number = number};
                    service.AddUser(user);
                    Console.WriteLine("User Added.");
                    break;

                case 2:
                    var users = service.GetAllUsers();
                    if (users.Count == 0) Console.WriteLine("No Users Found.");
                    foreach (var item in users)
                    {
                        Console.WriteLine();

                        Console.WriteLine($"Id: {item.Id}");
                        Console.WriteLine($"Name: {item.Name}");
                        Console.WriteLine($"Email: {item.Email}");
                        Console.WriteLine($"Number: {item.Number}");
                    }
                    break;

                case 3:
                    Console.Write("Enter User Id: ");
                    int emailUserId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Message: ");
                    string emailMessage = Console.ReadLine() ?? string.Empty;

                    service.SendNotification(new EmailNotification(), emailUserId, emailMessage, "Email");
                    break;

                case 4:

                    Console.Write("Enter User Id: ");
                    int smsUserId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Message: ");
                    string smsMessage = Console.ReadLine() ?? string.Empty;

                    service.SendNotification(new SmsNotification(), smsUserId, smsMessage, "SMS");
                    break;

                case 5:
                    var notifications = service.GetAllNotifications();
                    if (notifications.Count == 0) Console.WriteLine("No Notifications Found.");
                    foreach (var notification in notifications)
                    {
                        Console.WriteLine();

                        Console.WriteLine($"Id: {notification.Id}");
                        Console.WriteLine($"Message: {notification.Message}");
                        Console.WriteLine($"Type: {notification.Type}");
                        Console.WriteLine($"Sent At: {notification.SentAt}");
                        Console.WriteLine($"User Id: {notification.UserId}");
                    }
                    break;

                case 6:
                    Console.Write("Enter Notification Id: ");
                    int notificationId = Convert.ToInt32(Console.ReadLine());

                    service.DeleteNotification(notificationId);
                    Console.WriteLine("Notification Deleted.");

                    break;

                case 7:
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid Choice.");
                    break;
            }
        }
    }
}