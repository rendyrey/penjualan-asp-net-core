using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Penjualan.Controllers
{
    public class CobaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}