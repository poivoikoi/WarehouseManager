using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManager1._2.Data
{
    [Table("NumeratorAllocations", Schema = "TIGER")]
    public class NumeratorAllocation
    {
        [Key]
        public int AllocationID { get; set; }
        public int NumeratorID { get; set; }
        public string TableName { get; set; }


        public Numerator Numerator { get; set; }
    }
}
