using BusinessLayer.Data;
using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AssignmentDbContext _assignmentDbContext;
        private DbSet<T> entities;
        public Repository(AssignmentDbContext assignmentDbContext)
        {
            _assignmentDbContext = assignmentDbContext;
            entities = _assignmentDbContext.Set<T>();
        }
     

        public T Get(Guid Id)
        {
            return entities.SingleOrDefault(c => c.Id == Id);
        }

        public IQueryable<T> GetAll()
        {
            return entities.AsQueryable();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _assignmentDbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _assignmentDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            _assignmentDbContext.SaveChanges();
        }
    }
}
