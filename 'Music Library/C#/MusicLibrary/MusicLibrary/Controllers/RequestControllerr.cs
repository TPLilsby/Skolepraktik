using Microsoft.AspNetCore.Mvc;
using MusicLibrary;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using MailKit.Net.Smtp;


namespace MusicLibrary.Controllers
{

    // Attribute to mark the class as an API controller
    [ApiController]

    //Attribute to specify the base route for action methods
    [Route("[action]")]

    public class RequestController : ControllerBase
    {
        //Private variable logger instance for logging purposes
        private readonly ILogger<RequestController> _logger;

        //Private variable to store database manager instance
        private readonly DALManager _database;

        //Constructor for the APIController class
        public RequestController(ILogger<RequestController> logger, DALManager database)
        {
            //Assigning the provided ILogger instance to _logger
            _logger = logger;

            //Assigning the provided DALManager instance to _database
            _database = database;
        }

        //HTTP POST action method with the name RequestSong
        [HttpPost(Name = "RequestSong")]

        //Void method for SubmitContact and makes an object of Request
        public void RequstSong(Request request)
        {
            //New email message
            var email = new MimeMessage();
            
            //From email
            email.From.Add(MailboxAddress.Parse(request.Email));

            //To email
            email.To.Add(MailboxAddress.Parse("ttlilsby@gmail.com"));

            //Email subject content
            email.Subject = "New Song Request";

            //Email body content
            email.Body = new TextPart(TextFormat.Plain)
            {
                Text = $" Artist Name: {request.ArtistName}" +
                $"\n Song Name: {request.SongName}"
            };

            //Create and connect to an SMTP client
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

            //Authenticate with the SMTP server using the email credentials
            smtp.Authenticate("ttlilsby@gmail.com", "ellribhxraqntizj");

            //Send the email
            smtp.Send(email);

            //Disconnect the SMTP server
            smtp.Disconnect(true);
        }
    }
}
