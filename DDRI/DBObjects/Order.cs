//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DDRI.DBObjects
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int ID { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<System.DateTime> EstimatedDeliveryDate { get; set; }
        public Nullable<System.DateTime> DeliveredOn { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<bool> IsCanceled { get; set; }
        public string ETAMin { get; set; }
        public string DeliveredMins { get; set; }
        public Nullable<bool> IsDelivered { get; set; }
    }
}
