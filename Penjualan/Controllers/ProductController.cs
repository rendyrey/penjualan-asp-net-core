using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Penjualan.ViewModels.Product;
using Penjualan.Utilities;
using RestSharp;
using Penjualan.ViewModels;
using Newtonsoft.Json;

namespace Penjualan.Controllers
{
    public class ProductController : Controller
    {
        string url = ApiUrl.PenjualanUrl;
        public IActionResult Index()
        {
            var endpoint = url + "Get";
            //var data = RestAPIHelper<CustomDataSourceResult<ListProductsViewModel>>.Submit("", Method.GET, endpoint);
            //ViewBag.product = JsonConvert.DeserializeObject(data);
            var datamodel = RestAPIHelper<List<ListProductsViewModel>>.Submit("", Method.GET, endpoint);
            var dataobject = RestAPIHelper<object>.Submit("", Method.GET, endpoint);
            ViewBag.product = dataobject;
            //ViewBag.product2 = datamodel;
            return View(datamodel);
            //return Ok("HI");
        }
    }
}