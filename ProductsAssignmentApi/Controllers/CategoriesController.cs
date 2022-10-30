using BusinessLayer.Models;
using BusinessLayer.Models.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ServiceLayer.ICustomServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProductsAssignmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICustomService<CategoryEntity> _categoryService;
        public CategoriesController(ICustomService<CategoryEntity> categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }
        [HttpGet]
        public CustomResult<IEnumerable<CategoryEntity>> GetCategories()
        {
            var categories = _categoryService.GetAll();
            return new CustomResult<IEnumerable<CategoryEntity>>
            {
                IsSuccessfull = true,
                Data = categories,
            };
        }

        [HttpOptions]
        public IActionResult GetCategoriesOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS");
            return Ok();
        }
    }
}
