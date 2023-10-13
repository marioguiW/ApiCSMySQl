using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels
{
    public class CreateTodoViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}
