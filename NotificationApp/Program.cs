using Microsoft.EntityFrameworkCore;
using NotificationDALLibrary;
using NotificationBLLibrary;
using NotificationModelLibrary.Models;

public class Program {
    static void Main(string[] args)
    {
    var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql("host=localhost;Port=5432;Username=murasaki;Password=123456;Database=notificationdb")
            .Options;
        
        var context = new AppDbContext(options);
        EmailNotification emailnotif = new EmailNotification();
        SmsNotification smsnotif = new SmsNotification();
        NotificationService notification = new NotificationService(context, emailnotif, smsnotif);

        System.Console.WriteLine("Enter a number: 1: add user, 2: view all users, 3: to send notification, 4: to view past notifications");
        string choice = System.Console.ReadLine()!;

        switch(choice)
        {
            case "1":
                System.Console.WriteLine("Enter name:");
                string name = Console.ReadLine()!;
                System.Console.WriteLine("Enter email:");
                string email = Console.ReadLine()!;
                System.Console.WriteLine("Enter number:");
                string number = Console.ReadLine()!;

                User user = new User(name, email, number )
                
;
                notification.AddUser(user);
                break;

            case "2":
                var users = notification.GetAllUsers();
                foreach(User userr in users)
                      System.Console.WriteLine($"name: {userr.Username}, id: {userr.Id}");                
                
                break;  

            case "3":
                System.Console.WriteLine("Enter id:");
                int id = Convert.ToInt32(Console.ReadLine()!);
                System.Console.WriteLine("Enter message:");
                string message = Console.ReadLine()!;
                System.Console.WriteLine("Enter notification type:");
                string type = Console.ReadLine()!;
                
                Notification notifi = new Notification();
                notifi.UserId = id;
                notifi.Message = message;
                notifi.NotificationType = type;

                notification.SendNotification(notifi);
                break;

            case "4":
                List<Notification> notificationHistory = new List<Notification>();
                notificationHistory = notification.GetNotifications();

                foreach(Notification notif in notificationHistory) 
                    System.Console.WriteLine($"to: {notif.User.Username}, Message: {notif.Message}, Type: {notif.NotificationType}");
                break;

            default:
                Console.WriteLine("Invalid choice");
                break;
        }    
    }
}

