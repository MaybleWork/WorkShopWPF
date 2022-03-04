using System;
using WorkShopWPF.DataAccess;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkShopWPF.Model;
using System.Collections.ObjectModel;
using System.Windows.Data;
using WorkShopWPF.DAL.Impl.Mappers;
using WorkShopWPF.DAL.Impl;
using WorkShopWPF.BL.Impl;
using WorkShopWPF.DAL.Impl.Entitie;


namespace WorkShopWPF.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {

        private UnitOfWork _UnitOfWork;

        public MainViewModel()
        {

            WorkShopContext context = new WorkShopContext();
            _UnitOfWork = new UnitOfWork(context);
         
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        List<string> _GetCollection;
        public List<string> GetCollection
        {
            get => _GetCollection;
            set
            {
                _GetCollection = value;
                OnPropertyChanged("GetCollection");
            }
        }

        string _RecipeName;
        public string RecipeName
        {
            get => _RecipeName;
            set
            {
                _RecipeName = value;
            }
        }

        int _RecipeQuantity;
        public int RecipeQuantity
        {
            get => _RecipeQuantity;
            set
            {
                _RecipeQuantity = value;
            }
        }

        string _GetPrice;
        public string GetPrice
        {
            get => _GetPrice;
            set
            {
                _GetPrice = value;
                OnPropertyChanged("GetPrice");
            }
        }


        RelayCommand _GetListCommand;
        public ICommand GetListCommand
        {
            get
            {
                if (_GetListCommand == null)
                    _GetListCommand = new RelayCommand(ExecuteGetListCommand, CanExecuteGetListCommand);
                return _GetListCommand;
            }
        }
        private void ExecuteGetListCommand(object parameter)
        {
            RecipeService _RecipeService = new RecipeService(_UnitOfWork);

            WorkShopDTO.Recipes = RecipeMapper.Map(_UnitOfWork.Recipes.ListEntities(), _UnitOfWork);

            WorkShopDTO.MaterialsInStorage = MaterialInWorkShopMapper.Map(_UnitOfWork.MaterialsInWorkShop.ListEntities());

            foreach (RecipeDTO R in WorkShopDTO.Recipes)
            {
                R.MaterialsForRecipe = _RecipeService.GetMaterialsWhereRecipeId(R.ID);
            }

            GetCollection = OrderDTO.GetRecipes();
        }
        private bool CanExecuteGetListCommand(object parameter)
        {
            return true;
        }

        RelayCommand _AddOrderCommand;
        public ICommand AddOrderCommand
        {
            get
            {

                if (_AddOrderCommand == null)
                    _AddOrderCommand = new RelayCommand(ExecuteAddOrderCommand, CanExecuteAddOrderCommand);
                return _AddOrderCommand;
            }
        }

        private void ExecuteAddOrderCommand(object parameter)
        {
            OrderDTO.AddOrder(RecipeName, RecipeQuantity);
        }

        private bool CanExecuteAddOrderCommand(object parameter)
        {
            return true;
        }


        RelayCommand _ComputeCommand;
        public ICommand ComputeCommand
        {
            get
            {
                if (_ComputeCommand == null)
                    _ComputeCommand = new RelayCommand(ExecuteComputeCommand, CanExecuteComputeCommand);
                return _ComputeCommand;
            }
        }
        private void ExecuteComputeCommand(object parameter)
        {
            GetPrice = OrderDTO.Compute();       

            OrderDTO.Clear();

        }
        private bool CanExecuteComputeCommand(object parameter)
        {
            return true;
        }
  

      
    }
}
