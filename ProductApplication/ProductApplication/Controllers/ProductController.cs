using ProductApplication.Models.Entity;
using ProductApplication.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductApplication.Controllers
{
    public class ProductController : Controller
    {
        ProductEntities dbContext = new ProductEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateProduct()
        {
            ProductViewModel model = GetCategories();
            return PartialView(model);
        }

        private ProductViewModel GetCategories()
        {
            ProductViewModel model = new ProductViewModel();
            model.Categories = new List<SelectListItem>();
            model.Categories.Add(new SelectListItem { Value = "0", Text = "Select Category" });
            foreach (var item in dbContext.Categories)
            {
                model.Categories.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }
            return model;
        }

        [HttpPost]
        public ActionResult SaveProduct(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();
                product.CategoryId = model.Category;
                product.Description = model.Description;
                product.Name = model.Name;
                product.Price = model.Price.Value;
                product.Quantity = model.Quantity.Value;
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        public ActionResult ListProducts()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            foreach (var item in dbContext.Products)
            {
                ProductViewModel model = new ProductViewModel
                {
                    ProductId = item.Id,
                    CategoryName = item.Category.Name,
                    Description = item.Description,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity
                };

                products.Add(model);
            }
            ViewBag.Products = products;
            return PartialView();
        }

        public ActionResult EditProduct(int productId)
        {
            ProductViewModel model = GetCategories();
            var productToUpdate = dbContext.Products.Find(productId);
            if (productToUpdate != null)
            {
                model.ProductId = productToUpdate.Id;
                model.Category = productToUpdate.CategoryId;
                model.Description = productToUpdate.Description;
                model.Name = productToUpdate.Name;
                model.Price = productToUpdate.Price;
                model.Quantity = productToUpdate.Quantity;
            }

            return PartialView("CreateProduct", model);
        }

        [HttpPost]
        public ActionResult UpdateProduct(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var productToUpdate = dbContext.Products.Find(model.ProductId);
                productToUpdate.CategoryId = model.Category;
                productToUpdate.Description = model.Description;
                productToUpdate.Name = model.Name;
                productToUpdate.Price = model.Price.Value;
                productToUpdate.Quantity = model.Quantity.Value;
                dbContext.Entry(productToUpdate).State = System.Data.EntityState.Modified;
                dbContext.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false});
            }
        }

        [HttpDelete]
        public ActionResult DeleteProduct(int productId)
        {
            var product = dbContext.Products.Find(productId);
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
            return Json(new { success = true });
        }

    }
}
