using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LRAdvanced.Service.Common.EmailService
{
    public class EmailService
    {
        public static (string rand, string status) VerifMail(string email)
        {
            Random rd = new Random();
            int rand_num = rd.Next(100000, 999999);
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("lradvanced2331@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Action Verification";
                mail.Body =
                    $"Hi," +
                    $"Please verify action\n" +
                    $"YOUR CODE IS - {rand_num}\n"
                    + "DON'T LET ANYONE TO KNOW THIS CODE OTHER THAN US\n";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("lradvanced2331@gmail.com", "ymdugnfwiayeqdhx");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return ($"{rand_num}", "Success");
            }
            catch (Exception ex)
            {
                return ("0", ex.Message);
            }
        }
    }
}
