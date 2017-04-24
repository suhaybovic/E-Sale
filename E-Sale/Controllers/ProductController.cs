using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Sale.Models;
using AutoMapper;

namespace E_Sale.Controllers
{
    public class ProductController : Controller
    {
        ESaleContext ESaleContext = new ESaleContext();

        public ActionResult Index(string type)
        {
            var list = ESaleContext.getProductsbyType(type);
            var listDto = Mapper.Map<List<MVCProduct>>(list);
            return View(listDto);
        }

        public ActionResult Details(int id)
        {
            var product = ESaleContext.getProductByID(id);
            var productDto = Mapper.Map<MVCProduct>(product);
            return View(productDto);
        }
	}
}