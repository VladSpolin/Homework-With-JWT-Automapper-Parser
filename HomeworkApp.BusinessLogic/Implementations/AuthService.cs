using HomeworkApp.Cryptography;
using HomeworkApp.Model;
using HomeworkApp.Model.DatabaseModels;
using HomeworkApp.BusinessLogic.Interfaces;
using HomeworkApp.Model.ViewModels.Auth;
using HomeworkApp.Model.ViewModels.User;
using AutoMapper;

namespace HomeworkApp.BusinessLogic.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public AuthService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public UserViewModel SingIn(TokenViewModel model)
        {
            if (!_context.Users.Any(x => x.Email == model.Email)) throw new Exception("User not found.");
            var user = _context.Users.FirstOrDefault(x => x.Email == model.Email);
            if (user.PasswordHash != PasswordHasher.HashPassword( model.Password)) throw new Exception("Invalid password.");
            return _mapper.Map<User, UserViewModel>(user);
        }
    }
}
