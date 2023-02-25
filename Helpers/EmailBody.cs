using static System.Net.Mime.MediaTypeNames;

namespace Ticketback.Helpers
{
    public static class EmailBody
    {
        public static string EmailStringBody(string email, string emailToken)
        {
            return $@"<html>
            <head>
            </head>
            <body>
               <div>
                <div>
                 <div>
                   <h1>Reset your Password</h1>
                   <hr>
                   <p>You're receiving this e-mail because you request a password reset for your Telnet Holding account</p>
                   <p>Please tap the link below to choose a new password</p>
                   <a href=""http://localhost:63958/reset-password?email={email}&code={emailToken}""> Reset Password </a><br>
                   <p> Kind Regards,<br><br> Telnet Holding </p>
                </div>
               </div>
              </div>

            </body >
            </html > ";
        }
    }
}