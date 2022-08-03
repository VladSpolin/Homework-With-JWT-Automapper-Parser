using HomeworkApp.Model.ViewModels.Clothes;
using HomeworkApp.Model.DatabaseModels;

namespace HomeworkApp.BusinessLogic.Interfaces
{
    public interface IClothesService
    {
        ClothesViewModel Get(int id);
        IQueryable<Clothes> GetClothes(int id);
        IEnumerable<Clothes> GetAll();
        void Create(CreateClothesViewModel model);
        void Add();
        void Delete(int id);
    }
}
