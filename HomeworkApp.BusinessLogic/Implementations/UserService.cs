
using HomeworkApp.BusinessLogic.Interfaces;
using HomeworkApp.Model;
using AutoMapper;
using HomeworkApp.Model.DatabaseModels;
using HomeworkApp.Model.ViewModels.User;
using HomeworkApp.Cryptography;

namespace HomeworkApp.BusinessLogic.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public UserService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(CreateUserViewModel model)
        {
            if (_context.Users.Any(x => x.Email == model.Email))
                throw new Exception("User with this email is already registered.");

            var user = _mapper.Map<CreateUserViewModel, User>(model);

            user.Name = model.Name;
            user.Email = model.Email;
            user.PasswordHash = PasswordHasher.HashPassword(model.Password);

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Users.Remove(GetUser(id).FirstOrDefault());
            _context.SaveChanges();
        }

        public void Edit(int id, EditUserViewModel model)
        {
            var user = GetUser(id).FirstOrDefault();
            var editedUser = _mapper.Map<EditUserViewModel, User>(model, user);
            editedUser.Name = model.Name;
            editedUser.Email = model.Email;
            _context.Users.Update(editedUser);
            _context.SaveChanges();
        }

        public UserViewModel Get(int id)
        {
            return _mapper.Map<User, UserViewModel>(GetUser(id).FirstOrDefault());
        }

        public IQueryable<User> GetUser(int id)
        {
            if (!_context.Users.Any(x => x.Id == id)) throw new Exception("User not found.");

            return _context.Users.Where(x => x.Id == id);
        }
    }
}
