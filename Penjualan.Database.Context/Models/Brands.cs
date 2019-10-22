using System;
using System.Collections.Generic;

namespace Penjualan.Database.Context.Models
{
    public partial class Brands
    {
        public Brands()
        {
            Products = new HashSet<Products>();
        }

        public int BrandId { get; set; }
        public string NamaBrand { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
