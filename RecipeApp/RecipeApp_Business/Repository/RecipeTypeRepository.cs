using RecipeApp_Business.Repository.IRepository;
using RecipeModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeApp_DataAccess.Folder;
using RecipeApp_DataAccess;
using AutoMapper;

namespace RecipeApp_Business.Repository
{
    public class RecipeTypeRepository : IRecipeTypeRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;

        public RecipeTypeRepository(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public RecipeTypeDTO Create(RecipeTypeDTO objDTO)
        {
            var recipeType = _mapper.Map<RecipeTypeDTO, RecipeType>(objDTO);
            recipeType.CreateDate = DateTime.Now;
            var addedObj = _db.RecipeTypes.Add(recipeType);

            _db.SaveChanges();

            return _mapper.Map<RecipeType, RecipeTypeDTO>(addedObj.Entity);
        }

        public int Delete(int id)
        {
            var obj = _db.RecipeTypes.FirstOrDefault(u => u.Id == id);
            if(obj != null)
            {
                _db.RecipeTypes.Remove(obj);
                return _db.SaveChanges();
            }
            return 0;
        }

        public RecipeTypeDTO Get(int id)
        {
            var obj = _db.RecipeTypes.FirstOrDefault(u => u.Id == id);
            if (obj != null)
            {
                return _mapper.Map<RecipeType, RecipeTypeDTO>(obj);
            }
            return new RecipeTypeDTO();
        }

        public IEnumerable<RecipeTypeDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<RecipeType>, IEnumerable<RecipeTypeDTO>>(_db.RecipeTypes);      
        }

        public RecipeTypeDTO Update(RecipeTypeDTO objDTO)
        {
            var objFromDb = _db.RecipeTypes.FirstOrDefault(u => u.Id == objDTO.Id);
            if(objFromDb != null)
            {
                objFromDb.Name=objDTO.Name;
                _db.RecipeTypes.Update(objFromDb);
                _db.SaveChanges();
                return _mapper.Map<RecipeType, RecipeTypeDTO>(objFromDb);
            }
            return objDTO;
        }
    }
}
