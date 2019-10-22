using System;
using System.Collections.Generic;
using System.Text;

namespace Penjualan.ViewModels.Product
{
    public class ListProductsViewModel
    {
        public string ProductID { get; set; }
        public string NamaProduct { get; set; }
        public string BrandNama { get; set; }
        public string TipeNama { get; set; }
        public decimal Harga { get; set; }
        public int Jumlah { get; set; }
    }
}
