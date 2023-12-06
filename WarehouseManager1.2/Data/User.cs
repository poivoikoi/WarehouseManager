using Google.Apis.Admin.Directory.directory_v1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WarehouseManager1._2.Data
{
    [Table("Users", Schema = "TIGER")]
    public class User
    {
        public int UserID { get; set; }
        [Column ("USERNAME")]
        public string Username { get; set; }
        public string Password { get; set; }
        [Column("UserType")]
        public string UserType { get; set; }
        //public UserType Role { get; set; }

        // Navigation Properties
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
