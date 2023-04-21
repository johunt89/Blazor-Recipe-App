using AutoMapper;
using RecipeApp_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeModels.Models;

namespace RecipeApp_Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RecipeType, RecipeTypeDTO>().ReverseMap();
        }
    }
}
