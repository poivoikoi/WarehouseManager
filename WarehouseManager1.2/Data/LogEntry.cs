using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManager1._2.Data
{
    public class LogEntry
    {
        public int LogEntryID { get; set; }
        public int UserID { get; set; }
        public DateTime LogDateTime { get; set; }
        public string Action { get; set; }

        // Navigation Property
        public User User { get; set; }
    }
}
