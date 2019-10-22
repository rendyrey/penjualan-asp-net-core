using System;
using System.Collections.Generic;

namespace Penjualan.Database.Context.Models
{
    public partial class Products
    {
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public int TipeId { get; set; }
        public string NamaProduct { get; set; }
        public decimal Harga { get; set; }
        public int Jumlah { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public virtual Brands Brand { get; set; }
        public virtual Tipe Tipe { get; set; }
    }
}
