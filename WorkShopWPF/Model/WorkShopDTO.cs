using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WorkShopWPF.Model
{
    public class WorkShopDTO
    {
        private static List<MaterialDTO> materialsInStorage = new List<MaterialDTO>();
        private static List<RecipeDTO> recipes = new List<RecipeDTO>();
        private static List<OrderDTO> orders = new List<OrderDTO>();

        internal static List<MaterialDTO> MaterialsInStorage { get => materialsInStorage; set => materialsInStorage = value; }
        internal static List<RecipeDTO> Recipes { get => recipes; set => recipes = value; }
        internal static List<OrderDTO> Orders { get => orders; set => orders = value; }
   
    }
}
