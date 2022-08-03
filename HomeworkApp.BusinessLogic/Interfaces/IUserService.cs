using HomeworkApp.Model.DatabaseModels;
using HomeworkApp.Model.ViewModels.User;

namespace HomeworkApp.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        UserViewModel Get(int id);
        IQueryable<User> GetUser(int id);
        void Create(CreateUserViewModel model);
        void Delete(int id);
        void Edit(int id, EditUserViewModel model);
    }
}
