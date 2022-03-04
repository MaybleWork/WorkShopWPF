using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShopWPF.Model;
using WorkShopWPF.DAL.Impl.Entitie;

namespace WorkShopWPF.DAL.Impl.Mappers
{
    public class NewMaterialMapper : IMapper<MaterialDTO, RecipeMaterial>
    {
        public RecipeMaterial MapFrom(MaterialDTO data)
        {
            throw new NotImplementedException();
        }

        public MaterialDTO MapTo(RecipeMaterial data)
        {
            return new MaterialDTO()
            {
                ID = data.Material.ID, /// data.MaterialID ?
                Name = data.Material.Name,
                Quantity = data.Material.Quantity
            };
        }
    }
}
