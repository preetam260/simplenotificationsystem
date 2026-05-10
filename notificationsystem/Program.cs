using System.IO.Compression;

public class Program
{
    static void Main(string[] args)
    {
        var user = new User("Preetam", "kspreetam2608@gmail.com", "9876543210");

        var service = new NotificationService();

        // service.SendNotification(new EmailNotification(), user,"Hii mail sent using SMTP(Email Notification)");

        service.SendNotification(new SmsNotification(), user, "Hii message sent using SMS(Sms Notification)");

        // if company wants to send notification to all users at once :

        // var employees = new List<User> { new User("S Preetam", "spreetam@gmail.com", "1234567890"), 
        //                 new User("Preetam S", "preetams@gmail.com", "9876543211")
        // };

        // foreach(var emp in employees) {
        //     service.SendNotification(new EmailNotification(), emp, "Hii everyone");
        //     service.SendNotification(new SmsNotification(), emp, "Hii everyone");
        // }

    }
}
