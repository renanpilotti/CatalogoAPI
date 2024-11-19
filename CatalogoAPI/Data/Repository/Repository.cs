using CatalogoAPI.Context;
using CatalogoAPI.Data.Interfaces;
using CatalogoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace CatalogoAPI.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly CatalogoAPIDbContext _context;

        public Repository(CatalogoAPIDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> Get(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);

            return entity;
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            
            _context.Set<T>().Remove(entity);

            return entity;
        }
    }
}
