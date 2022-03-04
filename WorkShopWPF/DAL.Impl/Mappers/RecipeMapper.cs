using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShopWPF.DAL.Impl.Entitie;
using WorkShopWPF.Model;


namespace WorkShopWPF.DAL.Impl.Mappers
{
    public static class RecipeMapper
    {
        public static RecipeDTO Map(Recipe entity, UnitOfWork _UnitOfWork)
        {
            return new RecipeDTO()
            {
                ID = entity.ID,
                Name = entity.Name,
            };
        }

        public static List<RecipeDTO> Map(List<Recipe> entities, UnitOfWork _UnitOfWork)
        {
            return entities.Select(obj => Map(obj, _UnitOfWork)).ToList();
        }

        public static Recipe DeMap(RecipeDTO model, UnitOfWork _UnitOfWork)
        {
            foreach (MaterialDTO M in model.MaterialsForRecipe)
            {
                _UnitOfWork.RecipeMaterials.Insert(new RecipeMaterial()
                {
                    RecipeID = model.ID,
                    MaterialID = M.ID
                });
            }
            return new Recipe()
            {
                ID = model.ID,
                Name = model.Name
            };
        }
    }
}
