
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using System.Text;
using WebApplication2.ViewModels;

namespace WebApplication2.Pages
{
    public class ContactUsModel : PageModel
    {
        [BindProperty]     
        public string randomString { get; set; }
        [BindProperty]
        public string inputRandomString { get; set; }
        
        [BindProperty]
        public ContactUsViewModel contactUsViewModel { get; set; }
       
        private readonly Random _random = new Random();
        public void OnGet()
        {
        }
      
        public void OnGetRefreshCaptcha()
        {
            randomString = RandomString(5, false);
        }

        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.

            // char is a single Unicode character
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
        public async Task OnPost()
        {
            // await _emailSender.SendEmailAsync(Input.Email, "test sub", "test body");
            if (randomString == inputRandomString)
            {
                try
                {
                    string email = "aowbussiness@gmail.com";
                    string password = "ceopnistsqdnizmd";
                    using (MailMessage msz = new MailMessage())
                    {
                        msz.From = new MailAddress(email, "Accounting On Web"); //sender
                        msz.Subject = contactUsViewModel.Email;
                        msz.Body = contactUsViewModel.Email + contactUsViewModel.Body;
                        msz.IsBodyHtml = true;
                        msz.To.Add(new MailAddress(contactUsViewModel.Email));//can be multiple mail address where you want to send email
                                                                                   // msz.CC.Add(new MailAddress("tnd.itsolutions@gmail.com"));

                        //sender credentials
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.Credentials = new System.Net.NetworkCredential(email, password);

                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Send(msz);

                        await smtp.SendMailAsync(msz);
                    }
                   
                    contactUsViewModel = new ContactUsViewModel();
                    randomString = RandomString(5, false);
                    inputRandomString = string.Empty;
                   
                }
                catch (Exception ex)
                {
                   
                }
            }
            else
            {
              
            }

        }
    }
}
