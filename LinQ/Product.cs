using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    internal class Product
    {
        public int Id {  get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Category {  get; set; }
        public override string ToString()=>$"Id:{Id} name:{Name} Price:{Price}";
        
    }
}
