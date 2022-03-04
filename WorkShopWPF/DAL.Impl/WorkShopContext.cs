using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;
using WorkShopWPF.DAL.Impl.Entitie;
 
namespace WorkShopWPF.DAL.Impl
{
    public class WorkShopContext : DbContext
    {
        public WorkShopContext() : base(ConfigurationManager.ConnectionStrings["BDStandart"].ConnectionString)
        {
        }        
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialInWorkShop> StorageMaterials { get; set; }
        public DbSet<RecipeMaterial> RecipeMaterials { get; set; }
    }
}
