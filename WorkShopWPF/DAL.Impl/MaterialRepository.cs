using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShopWPF.DAL.Abstract;
using WorkShopWPF.DAL.Impl.Entitie;

namespace WorkShopWPF.DAL.Impl
{
    public class MaterialRepository : GenericRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(WorkShopContext context) : base(context)
        {

        }
    }
}
