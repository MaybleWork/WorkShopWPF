using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShopWPF.Model
{
    public class RecipeDTO
    {
        private int id;
        private string name;
        private List<MaterialDTO> materialsForRecipe = new List<MaterialDTO>();

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        internal List<MaterialDTO> MaterialsForRecipe { get => materialsForRecipe; set => materialsForRecipe = value; }

        public RecipeDTO()
        { }

        public RecipeDTO(string Name)
        {
            this.Name = Name;
        }
        
    }
}
