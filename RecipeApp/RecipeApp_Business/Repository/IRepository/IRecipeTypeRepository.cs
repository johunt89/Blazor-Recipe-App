using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using RecipeModels.Models;

namespace RecipeApp_Business.Repository.IRepository
{
    public interface IRecipeTypeRepository
    {
        public RecipeTypeDTO Create(RecipeTypeDTO objDTO);
        public RecipeTypeDTO Update(RecipeTypeDTO objDTO);
        public int Delete(int id);
        public RecipeTypeDTO Get(int id);
        public IEnumerable<RecipeTypeDTO> GetAll();
    }
}
