using System;
using System.Net;
using System.Net.Mail;

public class EmailNotification : INotification
{
    public void Send(User user, Notification notification)
    {
        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(
                "mail@mail",
                "16-digit app pwd"   
            )
        };
        var mailMessage = new MailMessage
        {
            From = new MailAddress("mail@mail"),
            Subject = "Notification",
            Body = notification.Message,
            IsBodyHtml = false
        };
        mailMessage.To.Add(user.Email); //recievers mail
        smtpClient.Send(mailMessage);
        Console.WriteLine("Email sent successfully.");
    }
}