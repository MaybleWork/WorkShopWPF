using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;
using WorkShopWPF.Model;


namespace WorkShopWPF.DataAccess
{
    class Loader
    {

        public static void LoadRecipeFromTxt(List<RecipeDTO> Recipes)
        {
            var path = ConfigurationManager.AppSettings["binfile2"];
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] strlist = line.Split(';');

                    RecipeDTO Recipe_n = new RecipeDTO(strlist[0]);

                    for (int l = 1; l < strlist.Length; l += 2)
                    {
                        ItemDTO baget = new ItemDTO(strlist[l], Convert.ToInt32(strlist[l + 1]));
                       // Recipe_n.MaterialsForRecipe.Add(baget);
                    }

                    Recipes.Add(Recipe_n);
                }
            }
        }
       
        public static void LoadMaterialsFromTxt(List<MaterialDTO> MaterialsInStorage)
        {
            var path = ConfigurationManager.AppSettings["binfile1"];
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine())
                    != null)
                {
                    string[] strlist = line.Split(';');

                    MaterialDTO Material = new MaterialDTO(strlist[0], Convert.ToInt32(strlist[1]), Convert.ToInt32(strlist[2]));

                    MaterialsInStorage.Add(Material);
                }
            }
        }
    }
}
