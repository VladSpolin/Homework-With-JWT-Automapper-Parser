using HomeworkApp.Model.DatabaseModels;
using HomeworkApp.Model.ViewModels.User;
using HomeworkApp.Model.ViewModels.Auth;

namespace HomeworkApp.BusinessLogic.Interfaces
{
    public interface IAuthService
    {
        UserViewModel SingIn(TokenViewModel model);
    }
}
