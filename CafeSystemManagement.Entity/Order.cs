using CafeManagementSystem.Common.CommonEntityProps;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks; 

namespace CafeSystemManagement.Entities
{
    public class Order : CommonEntityProps
    {
        [Key]
        public int OrderId { get; set; }  
        public DateTime OrderDate { get; set; } 
        public DateTime OrderTime { get; set; }
        public string UserName { get; set; }
        public string UserNumber { get; set; }

        //relationShip
        [ForeignKey("UserInfo")]
        public int UserId { get; set; }   
        public virtual UserInfo UserInfo { get; set; }
 
    }
}
