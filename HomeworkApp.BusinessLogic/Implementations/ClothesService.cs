
using HomeworkApp.BusinessLogic.Interfaces;
using HomeworkApp.Model.DatabaseModels;
using HomeworkApp.Model.ViewModels.Clothes;
using HomeworkApp.Model;
using AutoMapper;

namespace HomeworkApp.BusinessLogic.Implementations
{
    public class ClothesService : IClothesService
    {

        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly Parser.Parser _parser;

        public ClothesService(ApplicationContext context, IMapper mapper, Parser.Parser parser)
        {
            _context = context;
            _mapper = mapper;
            _parser = parser;
        }

        public void Add()
        {
            var clothes = _parser.Parse();
            foreach (var item in clothes)
            {
                Create(item);
            }

        }

        public void Create(CreateClothesViewModel model)
        {
            var clothes = _mapper.Map<CreateClothesViewModel, Clothes>(model);

            clothes.Brand = model.Brand;
            clothes.Description = model.Description;

            _context.ClothesTable.Add(clothes);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.ClothesTable.Remove(GetClothes(id).FirstOrDefault());
            _context.SaveChanges();
        }

        public ClothesViewModel Get(int id)
        {
            return _mapper.Map<Clothes, ClothesViewModel>(GetClothes(id).FirstOrDefault());
        }

        public IEnumerable<Clothes> GetAll()
        {
            if (_context.ClothesTable == null) throw new Exception("Clothes not found.");
            return  _context.ClothesTable.ToList();
        }

        public IQueryable<Clothes> GetClothes(int id)
        {
            if (!_context.ClothesTable.Any(x => x.Id == id)) throw new Exception("Clothes not found.");

            return _context.ClothesTable.Where(x => x.Id == id);
        }
    }
}
