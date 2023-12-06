using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManager1._2.Data
{
    [Table("Numerators", Schema = "TIGER")]
    public class Numerator
    {
        public int NumeratorID { get; set; }
        public string Name { get; set; }
        public int CurrentValue { get; set; }

        // Navigation Property
        public ICollection<NumeratorAllocation> NumeratorAllocations { get; set; }
    }
}
