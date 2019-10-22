using System;
using System.Collections.Generic;
using System.Text;

namespace Penjualan.ViewModels
{
    public class AjaxViewModel
    {

        public AjaxViewModel()
        {
        }
        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }

        public AjaxViewModel(bool isSuccess, object data, string message)
        {
            IsSuccess = isSuccess;
            Data = data;
            Message = message;
        }


    }
}
