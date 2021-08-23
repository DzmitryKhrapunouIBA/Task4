
using BLL.Contracts;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class CrudService<T> : BaseService, ICrudService<T>
        where T : class, IEntity
    {
        protected DbContext Context { get; }
        protected IQueryable<T> Entry { get; }
        protected IEnumerable<T> Project { get; }

        public CrudService(DbContext context) : base()
        {
            Context = context;

            Entry = Context.Set<T>().AsQueryable<T>().AsNoTracking();

            Project = Context.Set<T>().AsNoTracking();
        }

        public virtual IEnumerable<T> All()
        {
            return Entry.ToList();
        }

        public virtual IEnumerable<T> All(Func<T, bool> func, params Expression<Func<T, object>>[] includes)
        {
            var query = Entry;
            var projects = Project;

            projects = new List<T>();

            if (includes != null && includes.Any())
                query = includes.Aggregate(query, (x, y) => x.Include(y));

            if (func != null)
                projects = query.Where(func).ToList();

            return projects;
        }

        /// <summary>
        /// Создание сущности.
        /// </summary>
        /// <param name="item">Объект создаваемой сущности.</param>
        /// <returns>
        /// Возвращает объект созданной сущности.
        /// </returns>
        /// <exception cref="ArgumentNullException">If creation item is null or empty</exception>
        /// <exception cref="DbUpdateException">Save context operation exception</exception>
        /// <exception cref="DbUpdateConcurrencyException">Save context operation exception</exception>
        public virtual T Create(T item)
        {
            try
            {
                if (item == null)
                    throw new ArgumentNullException(nameof(T));

                var entry = Context.Set<T>().Add(item);
                Context.SaveChanges();

                return entry.Entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(int id)
        {
            try
            {
                var entry = Context.Set<T>().SingleOrDefault(x => x.Id == id);
                if (entry == null)
                    return false;

                Context.Set<T>().Remove(entry);
                Context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Получение единственной сущности по коду
        /// </summary>
        /// <param name="id">Код сущности.</param>
        /// <returns>
        /// Найденный элемент.
        /// </returns>
        /// <exception cref="ArgumentNullException">Single or default throw</exception>
        /// <exception cref="InvalidOperationException">Single or defaut throw</exception>
        public virtual T Get(int id)
        {
            var a = Entry.SingleOrDefault(x => x.Id == id);
            return Entry.SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Получение единственного элемента по выражению
        /// </summary>
        /// <param name="func">Функция поиска элемента.</param>
        /// <returns>
        /// Возвращает найденный элемент.
        /// </returns>
        /// <exception cref="ArgumentNullException">Throw at single or default </exception>
        /// <exception cref="InvalidOperationException">Throw at single or default </exception>
        public virtual T Get(Expression<Func<T, bool>> func)
        {
            return Entry.FirstOrDefault(func);
        }

        public virtual bool Update(T item)
        {
            try
            {
                if (item == null)
                    throw new ArgumentNullException(nameof(T));

                var entry = Context.Set<T>().Update(item);
                Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
