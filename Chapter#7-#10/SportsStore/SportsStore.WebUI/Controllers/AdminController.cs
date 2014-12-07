using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductRepository _productRepository;

        public AdminController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ViewResult Index()
        {
            return View(_productRepository.Products);
        }

        public ViewResult Edit(int productId)
        {
            var product = _productRepository.Products.FirstOrDefault(p => p.ProductId == productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            _productRepository.SaveProduct(product);
            TempData["Message"] = string.Format("{0} has been saved", product.Name);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View("Edit", new Product());
        }

        public ActionResult Delete(int productId)
        {
            var deletedProduct = _productRepository.Delete(productId);
            if (deletedProduct != null)
                TempData["Message"] = string.Format("{0} product was deleted.", deletedProduct.Name);
            return RedirectToAction("Index");
        }
    }
}
