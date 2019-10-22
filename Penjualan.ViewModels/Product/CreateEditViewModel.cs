using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Penjualan.ViewModels.Product
{
    public class CreateEditViewModel
    {
        public int ProductID { get; set; }
        [Required]
        public int BrandID { get; set; }
        [Required]
        public int TipeID { get; set; }
        [Required]
        [StringLength(50)]
        public string NamaProduct { get; set; }
        [Required]
        public int Jumlah { get; set; }
        [Required]
        public decimal Harga { get; set; }

    }
}
