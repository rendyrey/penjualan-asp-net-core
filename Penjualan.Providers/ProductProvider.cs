using Microsoft.EntityFrameworkCore;
using Penjualan.Database.Context.Models;
using Penjualan.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Penjualan.Providers
{
    public interface IProductService
    {
        int Add(Products entity);
        void Delete(int Id);
        int Edit(Products entity);
        Products Get(int Id);
        IQueryable<ListProductsViewModel> GetList();
    }
    public class ProductProvider : IProductService
    {
        PenjualanContext context;
        public ProductProvider(PenjualanContext context)
        {
            this.context = context;
        }

        public IQueryable<Products> AllProducts
        {
            get { return context.Products.AsNoTracking().Where(x => !x.DeletedAt.HasValue); }
        }

        public IQueryable<Brands> AllBrands
        {
            get { return context.Brands.AsNoTracking().Where(x => !x.DeletedAt.HasValue); }
        }

        public IQueryable<Tipe> AllTipes
        {
            get { return context.Tipe.AsNoTracking().Where(x => !x.DeletedAt.HasValue); }
        }

        public Products Get(int id)
        {
            return AllProducts.SingleOrDefault(x => x.ProductId == id);
        }

        public int Add(Products entity)
        {
            Products data = new Products();
            data.NamaProduct = entity.NamaProduct;
            data.BrandId = entity.BrandId;
            data.TipeId = entity.TipeId;
            data.Harga = entity.Harga;
            data.Jumlah = entity.Jumlah;
            data.CreatedAt = DateTime.Now;
            context.Add(data);
            return context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var product = Get(Id);
            if(product != null)
            {
                product.DeletedAt = DateTime.Now;
                context.Update(product);
                context.SaveChanges();
            }
        }

        public int Edit(Products entity)
        {
            context.Update(entity);
            return context.SaveChanges();
        }

        public IQueryable<ListProductsViewModel> GetList()
        {
            var query = from product in AllProducts
                        join brand in AllBrands on product.BrandId equals brand.BrandId
                        join tipe in AllTipes on product.TipeId equals tipe.TipeId
                        select new ListProductsViewModel()
                        {
                            ProductID = product.ProductId.ToString(),
                            NamaProduct = product.NamaProduct,
                            BrandNama = brand.NamaBrand,
                            TipeNama = tipe.NamaTipe,
                            Harga = product.Harga,
                            Jumlah = product.Jumlah
                        };
            return query;

        }



    }
}
