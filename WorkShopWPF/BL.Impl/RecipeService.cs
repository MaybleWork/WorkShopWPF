using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShopWPF.DAL.Impl.Entitie;
using WorkShopWPF.Model;
using WorkShopWPF.BL.Abstract;
using WorkShopWPF.DAL.Impl;
using WorkShopWPF.DAL.Impl.Mappers;



namespace WorkShopWPF.BL.Impl
{
    public class RecipeService : IRecipeService
    {

        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper<MaterialDTO, RecipeMaterial> _mapper; //Item  MAterial ?

        public RecipeService(UnitOfWork _UnitOfWork)
        {
            this._UnitOfWork = _UnitOfWork;
            _mapper = new NewMaterialMapper();
        }


        public List<MaterialDTO> GetMaterialsWhereRecipeId(int id)
        {
            List<MaterialDTO> materials = new List<MaterialDTO>();

            materials = _UnitOfWork.RecipeMaterials.GetWhereRecipe(id).Select(_mapper.MapTo).ToList();

            return materials;
        }
    }
}
