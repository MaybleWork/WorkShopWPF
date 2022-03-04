using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShopWPF.Model;

namespace WorkShopWPF.BL.Abstract
{
    public interface IRecipeService
    {
        List<MaterialDTO> GetMaterialsWhereRecipeId(int id);
    }
}
