using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using static NPOI.HSSF.Util.HSSFColor;
using static NPOI.SS.Formula.PTG.ArrayPtg;

namespace Bulky.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> DbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.DbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = DbSet;
            return query.FirstOrDefault(filter); //This executes the query with the specified filter condition,
                                                 //returning the first element that matches the condition.

            //IQueryable<T> query = DbSet;
            //query.Where(filter);
            //return query.FirstOrDefault(); 
            //You call the Where method on the query, passing the filter expression.
            //However, the result of this operation (filtered query) is not assigned back to the query variable.
            //The Where method does not modify the original query; it returns a new filtered query.
            //You then return the result of calling FirstOrDefault on the original query.
            //Since the Where operation didn't modify the original query, this FirstOrDefault call is executed on the unfiltered query, which is likely not what you intended.:
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = DbSet;
            return query.ToList();

        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            DbSet.RemoveRange(entity);
        }
    }
}
