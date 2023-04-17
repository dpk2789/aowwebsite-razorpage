namespace WebApplication2.ViewModels
{
    public class ContactUsViewModel
    {
        public int Id { get; set; }
        public string? To { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public bool IsMailSend { get; set; }
    }
}
