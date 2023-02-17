using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagementSystem.Common.CommonEntityProps
{
    public class CommonEntityProps
    {
        public DateTime? AddedDate { get; set; } = null;
        public int AddedBy { get; set; } = 0;
        public DateTime? UpdateDate { get; set; } = null;
        public int UpdateBy { get; set; } = 0;

    }
}
