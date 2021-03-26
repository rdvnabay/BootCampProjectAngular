using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;

        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var data=_productService.GetAll();
            return Ok(data);
        }

        [HttpGet("getallbycategory")]
        public IActionResult GetAllByCategory(int categoryId)
        {
            var data = _productService.GetAllByCategoryId(categoryId);
            return Ok(data);
        }
    }
}
