using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Management.Automation;

namespace WorkShopWPF.DAL.Impl.Entitie
{
    public class RecipeMaterial
    {
        [Key]
        public int ID { get; set; }

        [AllowNull]
        public int? MaterialID { get; set; }

        [ForeignKey(nameof(MaterialID))]
        public Material Material { get; set; }

        [AllowNull]
        public int? RecipeID { get; set; }

        [ForeignKey(nameof(RecipeID))]
        public Recipe Recipe { get; set; }
    }
}
