using System;
using System.Collections.Generic;
using System.Text;

namespace Penjualan.ViewModels
{
    
        public class CustomDataSourceResult<T>
        {
            public ICollection<T> data { get; set; }
            public int total { get; set; }
            public object aggregateResults { get; set; }
            public object errors { get; set; }
        }
    
}
