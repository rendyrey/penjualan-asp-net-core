using System;
using System.Collections.Generic;

namespace Penjualan.Database.Context.Models
{
    public partial class Tipe
    {
        public Tipe()
        {
            Products = new HashSet<Products>();
        }

        public int TipeId { get; set; }
        public string NamaTipe { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
