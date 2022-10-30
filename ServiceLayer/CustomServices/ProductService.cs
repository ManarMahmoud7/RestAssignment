using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using ServiceLayer.ICustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ServiceLayer.CustomServices
{
    public class ProductService : ICustomService<ProductEntity>
    {
        private readonly IRepository<ProductEntity> _productRepository;

        public ProductService(IRepository<ProductEntity> productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public ProductEntity Get(Guid Id)
        {
           return _productRepository.Get(Id);
        }

        public IEnumerable<ProductEntity> GetAll([OptionalAttribute] Guid categoryId)
        {
            if (categoryId == Guid.Empty)
                return _productRepository.GetAll().AsEnumerable();
            else
                return _productRepository.GetAll().Where(p => p.CategoryEntityId == categoryId);
        }

        public void Insert(ProductEntity entity)
        {
            _productRepository.Insert(entity);
            _productRepository.SaveChanges();
        }

        public void Update(ProductEntity entity)
        {
            _productRepository.Update(entity);
            _productRepository.SaveChanges();
        }
    }
}
