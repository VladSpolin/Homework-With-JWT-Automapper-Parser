using System.ComponentModel.DataAnnotations;


namespace HomeworkApp.Model.ViewModels.User
{
    public class EditUserViewModel
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
