using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManager1._2.Data
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }

        public Product Product { get; set; }
        public User User { get; set; }
    }
}
