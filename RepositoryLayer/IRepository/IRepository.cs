using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.IRepository
{
    public interface IRepository <T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        T Get(Guid Id);
        void Insert(T entity);
        void Update(T entity);
        void SaveChanges();
    }
}
