
using System.ComponentModel.DataAnnotations;

namespace HomeworkApp.Model.ViewModels.User
{
    public class CreateUserViewModel
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
