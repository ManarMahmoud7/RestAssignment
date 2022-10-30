using AutoMapper;
using BusinessLayer.Models;
using BusinessLayer.Models.Business;
using BusinessLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ServiceLayer.CustomServices;
using ServiceLayer.ICustomServices;
using System;
using System.Collections.Generic;

namespace ProductsAssignmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ICustomService<ProductEntity> _productService;
        private readonly IMapper _mapper;

        public ProductsController(ICustomService<ProductEntity> productService, IMapper mapper)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public CustomResult<IEnumerable<ProductEntity>> GetProducts(Guid categoryId)
        {
            var products = categoryId == Guid.Empty ?  _productService.GetAll() : _productService.GetAll(categoryId) ;
            return new CustomResult<IEnumerable<ProductEntity>>
            {
                IsSuccessfull = true,
                Data = products,
            };
        }

        [HttpGet("{id}")]
        public CustomResult<ProductEntity> GetProductById(Guid id)
        {
            if (id == Guid.Empty)
                return new CustomResult<ProductEntity>
                {
                    IsSuccessfull = false,
                    Data = null,
                    ValidationErrors = new List<string> { "Id parameter is emoty" }
                };

            var product = _productService.Get(id);
            return new CustomResult<ProductEntity>
            {
                IsSuccessfull = true,
                Data = product,
            };
        }

        [HttpPost]
        public IActionResult AddProduct(ProductUpdateDto product)
        {

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(new CustomResult<ProductEntity>
                {
                    IsSuccessfull = false,
                    Data = null,
                    ValidationErrors = HelperMethods.GetValidationErrors(ModelState)
                });
            }

            ProductEntity insertedProduct = _mapper.Map<ProductEntity>(product);

            _productService.Insert(insertedProduct);

            return Ok(new CustomResult<ProductEntity>
            {
                IsSuccessfull = true,
                Data = insertedProduct
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Guid id, ProductUpdateDto product)
        {

            if (id == Guid.Empty)

                return new UnprocessableEntityObjectResult(
                    new CustomResult<ProductEntity> {
                        IsSuccessfull = false,
                        Data = null,
                        ValidationErrors = new List<string> { "Product Id is empty " }
                    });

            else if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(
                    new CustomResult<ProductEntity> {
                        IsSuccessfull = false,
                        Data = null,
                        ValidationErrors = HelperMethods.GetValidationErrors(ModelState)
                    });
            }


            ProductEntity updatedProduct = _mapper.Map<ProductEntity>(product);

            updatedProduct.Id = id;

            _productService.Update(updatedProduct);

            return Ok(new CustomResult<ProductEntity>
            {
                IsSuccessfull = true,
                Data = updatedProduct
            });
        }

        [HttpOptions]
        public IActionResult GetProductsOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,PUT");
            return Ok();
        }
    }
}
