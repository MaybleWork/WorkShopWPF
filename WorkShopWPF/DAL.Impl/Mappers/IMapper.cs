using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShopWPF.DAL.Impl.Mappers
{
    internal interface IMapper<TModel, TEntity>
    {
        TModel MapTo(TEntity data);
        TEntity MapFrom(TModel data);
    }
}
