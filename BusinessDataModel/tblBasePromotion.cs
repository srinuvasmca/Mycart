//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblBasePromotion
    {
        public int PromotionId { get; set; }
        public string PromotionName { get; set; }
        public int SKUID { get; set; }
        public int SKUIDQuantity { get; set; }
        public int PromotionUnitPrice { get; set; }
        public bool Active { get; set; }
        public System.DateTime AddedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<int> ParentID { get; set; }
    
        public virtual tblSKUID tblSKUID { get; set; }
    }
}