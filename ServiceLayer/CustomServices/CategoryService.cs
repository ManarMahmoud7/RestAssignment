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
    public class CategoryService : ICustomService<CategoryEntity>
    {
        private readonly IRepository<CategoryEntity> _categoryRepository;

        public CategoryService(IRepository<CategoryEntity> categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public CategoryEntity Get(Guid Id)
        {
            return _categoryRepository.Get(Id);
        }

        public IEnumerable<CategoryEntity> GetAll([OptionalAttribute] Guid categoryId)
        {
            return _categoryRepository.GetAll().Include("Products").AsEnumerable();
        }

        public void Insert(CategoryEntity entity)
        {
             _categoryRepository.Insert(entity);
            _categoryRepository.SaveChanges();
        }

        public void Update(CategoryEntity entity)
        {
            _categoryRepository.Update(entity);
            _categoryRepository.SaveChanges();
        }
    }
}
