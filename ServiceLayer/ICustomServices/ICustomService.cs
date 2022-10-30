using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ServiceLayer.ICustomServices
{
    public interface ICustomService<T> where T : class
    {
        IEnumerable<T> GetAll([OptionalAttribute] Guid categoryId);
        T Get(Guid Id);
        void Insert(T entity);
        void Update(T entity);
    }
}