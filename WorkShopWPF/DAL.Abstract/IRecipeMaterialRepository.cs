using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShopWPF.DAL.Impl.Entitie;

namespace WorkShopWPF.DAL.Abstract
{
    interface IRecipeMaterialRepository : IGenericRepository<RecipeMaterial>
    {
        IEnumerable<RecipeMaterial> GetWhereRecipeId(int id);
        List<RecipeMaterial> GetWhereRecipe(int IdRecipe);
    }
}
