using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication17
{
    class email
    {
        public String sendEmail(string body, List<string> attachmentPath, string subject, List<string> to)
        {
            String mes = "sucess";
            
            try
            {
                int i= to.Count;                
                MailMessage mail = new MailMessage();
                mail.To.Add("sangrila.cafe@gmail.com");
                foreach(string add in to)
                {
                    mail.Bcc.Add(add);//receiver mail address
                }
               // mail.CC.Add("mr.outlive@gmail.com");
                mail.From = new MailAddress("mr.sanjeevjarga@gmail.com");//senders mail
                mail.Subject = subject;//subject of mail

                mail.Body = body;// message body
                mail.IsBodyHtml = true;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();


                if (attachmentPath.Count >0)
                {
                    System.Net.Mail.Attachment attachment;
                    foreach (string add in attachmentPath)
                    {
                        attachment = new System.Net.Mail.Attachment(add);
                        mail.Attachments.Add(attachment);
                    }
                    
                    
                   
                }
                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential
                     ("mr.sanjeevjarga@gmail.com", ""); // ***use valid credentials***
                smtp.Port = 587;

                //Or your Smtp Email ID and Password
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                mes = "failed";
            }
            return mes;
        }
    }

    //class for grid 
    class Grid
    {
        public Rectangle Rectangle { get; set; }
        public string GridName { get; set; }
        public Grid(Point location, Size size, string name)
        {
            GridName = name;
            Rectangle = new Rectangle(location, size);
        }
    } 
}
