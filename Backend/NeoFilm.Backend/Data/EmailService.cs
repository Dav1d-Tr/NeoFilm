namespace NeoFilm.Backend.Data
{
    public class EmailService
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _Port = 587;
        private readonly string _from = "neofilm88@gmail.com";
        private readonly string _password = "pmfd yecp gbtj dzhy";

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using (var client = new System.Net.Mail.SmtpClient(_smtpServer, _Port))
            {
                client.Credentials = new System.Net.NetworkCredential(_from, _password);
                client.EnableSsl = true;

                var mailMessage = new System.Net.Mail.MailMessage
                {
                    From = new System.Net.Mail.MailAddress(_from),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(to);

                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
