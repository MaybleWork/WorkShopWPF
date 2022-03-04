using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShopWPF.DAL.Abstract;
using WorkShopWPF.DAL.Impl.Entitie;
using System.Data.Entity;

namespace WorkShopWPF.DAL.Impl
{
    public class RecipeMaterialRepository : GenericRepository<RecipeMaterial>, IRecipeMaterialRepository
    {
        public RecipeMaterialRepository(WorkShopContext context) : base(context)
        {

        }

        public IEnumerable<RecipeMaterial> GetWhereRecipeId(int id)
        {
            return this.ListEntities(obj => obj.RecipeID == id);
        }

        public List<RecipeMaterial> GetWhereRecipe(int IdRecipe)
        {
            IQueryable<RecipeMaterial> data = (from bm in _dataContext.RecipeMaterials
                                              join
       b in _dataContext.Recipes on bm.RecipeID equals b.ID
                                              join m in _dataContext.Materials on bm.MaterialID equals m.ID
                                              where bm.RecipeID == IdRecipe
                                              select bm) 
                                              .Include(p => p.Material)
                                              .Include(p => p.Recipe);
            return data.ToList();

        }
    }
}
