using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Penjualan.Database.Context.Models;
using Penjualan.Providers;
using Penjualan.Utilities;
using Penjualan.ViewModels;
using Penjualan.ViewModels.Product;

namespace Penjualan.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IProductService _productProvider;
        public ProductController(IProductService service)
        {
            this._productProvider = service;
        }
        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            try
            {
                var model = new ListProductsViewModel();
                var product = _productProvider.GetList();
                return Ok(product);
            }catch(Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        [Route("Get/{ProductId}")]
        public IActionResult Get(int ProductId)
        {
            var model = new CreateEditViewModel();
            var product = _productProvider.Get(ProductId);
            if (product == null)
            {
                return NotFound("Product Not Found");
            }
         
            return Ok(product);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromForm]CreateEditViewModel model)
        {
            var product = new Products();
            if(model == null)
            {
                return BadRequest("Product is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            product.BrandId = model.BrandID;
            product.NamaProduct = model.NamaProduct;
            product.TipeId = model.TipeID;
            product.Harga = model.Harga;
            product.Jumlah = model.Jumlah;
            product.CreatedAt = DateTime.Now;
            _productProvider.Add(product);
            return Ok(product);
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Put([FromBody]CreateEditViewModel model)
        {
            if(model == null)
            {
                return BadRequest("Product is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var product = _productProvider.Get(Convert.ToInt32(model.ProductID));
            product.NamaProduct = model.NamaProduct;
            product.BrandId = model.BrandID;
            product.TipeId = model.TipeID;
            product.Jumlah = model.Jumlah;
            product.Harga = model.Harga;
            _productProvider.Edit(product);
            return Ok();
        }

        [HttpPost]
        [Route("Delete/{Id}")]
        public IActionResult Delete(string ID)
        {
            var model = new AjaxViewModel();
            var decryptID = Convert.ToInt32(ID);
            _productProvider.Delete(decryptID);
            return Ok();
        }
    }
}