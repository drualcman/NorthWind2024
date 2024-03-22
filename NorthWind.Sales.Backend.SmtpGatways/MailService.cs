using System.Net;
using System.Net.Mail;

namespace NorthWind.Sales.Backend.SmtpGatways;
/// <summary>
/// Send mail using https://mailtrap.io
/// </summary>
/// <param name="SmtpOptions"></param>
/// <param name="logger"></param>
internal class MailService(IOptions<SmtpOptions> SmtpOptions, ILogger<MailService> logger) : IMailService
{
    public async Task SendMailToAdministrator(string subject, string body)
    {
		try
		{
			MailMessage message = new MailMessage(SmtpOptions.Value.SenderEmail, SmtpOptions.Value.AdministratorEmail);
			message.Subject = subject;
			message.Body = body;

			SmtpClient client = new SmtpClient(SmtpOptions.Value.SmtpHost, SmtpOptions.Value.SmtpHostPort)
			{
				Credentials = new NetworkCredential(SmtpOptions.Value.SmtpUserName, SmtpOptions.Value.SmtpPassword),
				EnableSsl = true
			};
			
			await client.SendMailAsync(message);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, ex.Message);
		}
    }
}
