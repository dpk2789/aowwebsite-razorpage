using System.ComponentModel.DataAnnotations;


namespace WebApplication2.ViewModels
{
    public class EditPageViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
     
        public string? Body { get; set; }
    }
}
