using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessEntities
{
    public class PromotionModel
    {

        public int PromotionId { get; set; }
        public string PromotionName { get; set; }
        public string SKUName { get; set; }
        public int SKUIDQuantity { get; set; }
        public int PromotionUnitPrice { get; set; }
        public bool Active { get; set; }
        public System.DateTime AddedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<int> ParentID { get; set; }
    }

   
}