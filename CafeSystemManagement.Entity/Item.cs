


using CafeManagementSystem.Common.CommonEntityProps;

namespace CafeSystemManagement.Entities
{
    public class Item : CommonEntityProps
    {

        public int ItemId { get; set; } 
        public string ItemName { get; set; } 
        public decimal UnitPrice { get; set; }
        public string Category { get; set; }
         
        public virtual OrderDetail OrderDetail { get; set; }
    }
}