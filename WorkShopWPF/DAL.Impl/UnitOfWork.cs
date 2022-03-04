using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShopWPF.DAL.Impl
{
    public class UnitOfWork
    {
        private readonly WorkShopContext _dataContext;
        private RecipeRepository _RecipeRepository;
        private MaterialRepository _MaterialRepository;
        private RecipeMaterialRepository _RecipeMaterialRepository;
        private MaterialInWorkShopRepository _MaterialInWorkShopRepository;


        public UnitOfWork(WorkShopContext context)
        {
            _dataContext = context;
        }
        public RecipeRepository Recipes
        {
            get
            {
                if (_RecipeRepository == null)
                    _RecipeRepository = new RecipeRepository(_dataContext);
                return _RecipeRepository;
            }
        }
        public MaterialRepository Materials
        {
            get
            {
                if (_MaterialRepository == null)
                    _MaterialRepository = new MaterialRepository(_dataContext);
                return _MaterialRepository;
            }
        }

        public RecipeMaterialRepository RecipeMaterials
        {
            get
            {
                if (_RecipeMaterialRepository == null)
                    _RecipeMaterialRepository = new RecipeMaterialRepository(_dataContext);
                return _RecipeMaterialRepository;
            }
        }

        public MaterialInWorkShopRepository MaterialsInWorkShop
        {
            get
            {
                if (_MaterialInWorkShopRepository == null)
                    _MaterialInWorkShopRepository = new MaterialInWorkShopRepository(_dataContext);
                return _MaterialInWorkShopRepository;
            }
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
