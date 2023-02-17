using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeSystemManagement.Entities
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; } 
        public decimal UnitPrice { get; set; } 
        public decimal Amount { get; set; }
        public int Qty { get; set; } 
        public string ItemName { get; set; } 
        public string Category { get; set; }

        //relationShip
        [ForeignKey("Item"), InverseProperty("OrderDetail")] 
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }


        [ForeignKey("UserInfo"), InverseProperty("OrderDetail")]
        public int UserId { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
