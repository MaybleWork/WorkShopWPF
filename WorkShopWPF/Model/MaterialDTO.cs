using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShopWPF.Model
{
    public class MaterialDTO 
    {
        private int id;
        private string name;
        private int quantity;
        private int price;

        public int ID { get => id; set => id = value; }
        public int Price { get => price; set => price = value; }
        public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public MaterialDTO(string Name, int Quantity, int Price) 
        {
            this.Name = Name;
            this.Quantity = Quantity;
            this.Price = Price;
        }
        public MaterialDTO()
        {

        }
    }
}
