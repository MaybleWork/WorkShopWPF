using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;



namespace WorkShopWPF.Model
{
    public class OrderDTO : ItemDTO
    {
        private int id;
        private static int total;
        private static string basketStr;
        private RecipeDTO recipeLink;
        private static Dictionary<string, int> basket = new Dictionary<string, int>();

        public int IDO { get => id; set => id = value; }
        public static int Total { get => total; set => total = value; }
        public static string BasketStr { get => basketStr; set => basketStr = value; }
        internal RecipeDTO RecipeLink { get => recipeLink; set => recipeLink = value; }
        public static Dictionary<string, int> Basket { get => basket; set => basket = value; }


        public OrderDTO(string Name, int Quantity, RecipeDTO RecipeLink) : base(Name, Quantity)
        {
            this.Name = Name;
            this.Quantity = Quantity;
            this.RecipeLink = RecipeLink;
        }

        public OrderDTO() { }
        

        public static List<String> GetRecipes()
        {
            List<String> Recipes = new List<String>();

            foreach (RecipeDTO R in WorkShopDTO.Recipes)
            {
                Recipes.Add(R.Name);
            }
            return Recipes;
        }    

        public static void AddOrder(string RecipeName, int Quantity)
        {
            foreach (RecipeDTO R in WorkShopDTO.Recipes)
            {
                if (RecipeName == R.Name)
                {
                    OrderDTO Order_N = new OrderDTO
                    {
                        Name = RecipeName,
                        Quantity = Quantity,
                        RecipeLink = R
                    };

                    WorkShopDTO.Orders.Add(Order_N);
                }
            }
        }


        public static void GenBasketOfProd()
        {
            foreach (OrderDTO o in WorkShopDTO.Orders)
            {
                foreach (MaterialDTO i in o.RecipeLink.MaterialsForRecipe)
                {
                    if (Basket.ContainsKey(i.Name))
                    {
                        Basket[i.Name] += i.Quantity * o.Quantity;
                        
                    }
                    else
                    {
                        Basket.Add(i.Name, i.Quantity * o.Quantity);
                        
                    }
                }
            }
        }

        public static int CostСalculation()
        {
            foreach (KeyValuePair<string, int> c in Basket)
            {
                foreach (MaterialDTO i in WorkShopDTO.MaterialsInStorage)
                {
                    if (c.Key == i.Name)
                    {
                        Total += i.Price * c.Value;
                    }
                }
            }
            return Total;

        }
     

        public static string CostСalculation(Dictionary<string, int> Basket)
        {
            foreach (KeyValuePair<string, int> c in Basket)
            {
                BasketStr += (c.Key + " - " + c.Value + "\n");
            }
            return BasketStr;
        }

        public static bool AvailabilityMaterials(List<MaterialDTO> MaterialsInStorage)
        {
            foreach (KeyValuePair<string, int> c in Basket)
            {
                foreach (MaterialDTO i in MaterialsInStorage)
                {
                    if (c.Key == i.Name)
                    {
                        if (c.Value > i.Quantity)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public static string Compute()
        {
            string answer = null;

            OrderDTO.GenBasketOfProd();
            if (OrderDTO.AvailabilityMaterials(WorkShopDTO.MaterialsInStorage))
            {
                OrderDTO.CostСalculation(OrderDTO.Basket);
                answer = "Total price: " + OrderDTO.CostСalculation().ToString() + "$";
            }
            else

            {
                OrderDTO.CostСalculation(OrderDTO.Basket);
                answer = "Error, not enough materials, estimated price: " + OrderDTO.CostСalculation().ToString() + "$";
            }
            return answer;

        }

        public static void Clear()
        {
            Basket.Clear();
            Total = 0;
            BasketStr = "";

        }
    }
}
