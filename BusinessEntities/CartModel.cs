using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessEntities
{
    public class CartModel
    {

        public int SKUID { get; set; }
        public string SKUName { get; set; }       
        public int SKUIDQuantity { get; set; }
        public int UnitPrice { get; set; }
       
    }

  
}