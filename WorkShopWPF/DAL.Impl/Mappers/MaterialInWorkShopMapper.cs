using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShopWPF.Model;
using WorkShopWPF.DAL.Impl.Entitie;

namespace WorkShopWPF.DAL.Impl.Mappers
{
    public static class MaterialInWorkShopMapper
    {
        public static MaterialDTO Map(MaterialInWorkShop entity)
        {
            return new MaterialDTO()
            {

                ID = entity.ID,
                Name = entity.Name,
                Quantity = entity.Quantity,
                Price = entity.Price,
            };
        }

        /*public static Material DeMap(MaterialDTO model)
        {
            return new Material()
            {

                ID = model.ID,
                Name = model.Name,
                // Quantity = model.Quantity,
                //Price = model.Price,

            };
        }*/

        public static List<MaterialDTO> Map(List<MaterialInWorkShop> models)
        {
            return models.Select(obj => Map(obj)).ToList();
        }
    }
}
