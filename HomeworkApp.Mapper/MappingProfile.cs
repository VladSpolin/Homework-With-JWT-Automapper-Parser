using AutoMapper;
using HomeworkApp.Model.DatabaseModels;
using HomeworkApp.Model.ViewModels.User;
using HomeworkApp.Model.ViewModels.Clothes;

namespace HomeworkApp.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        { 
            CreateMap<CreateUserViewModel, User>();
            CreateMap<EditUserViewModel, User>();
            CreateMap<UserViewModel, User>();
            CreateMap<ClothesViewModel, Clothes>();
            CreateMap<CreateClothesViewModel, Clothes>();
        
        }
    }
}