using BusinessLogicLayer.DesignPatterns.GenericRepository.InterfaceRepo;
using BusinessLogicLayer.DesignPatterns.SingletonPattern;
using P.DataAccessLayer.Context;
using P.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLogicLayer.DesignPatterns.GenericRepository.BaseRepo
{
	public class BaseRepository<T> : IRepository<T> where T : BaseEntity
	{
		AppDbContext _db;
		public BaseRepository()
		{
			_db = DBTool.DbInstance;
		}

		public void Add(T entity)
		{
			_db.Set<T>().Add(entity);
			_db.SaveChanges();
		}

		public void AddRange(List<T> entities)
		{
			foreach (T item in entities)
			{
				Add(item);
			}
		}

		public bool Any(Expression<Func<T, bool>> exp)
		{
			return _db.Set<T>().Any(exp);
		}

		public void Delete(T entity)
		{
			entity.DeletedDate = DateTime.Now;
			entity.CurrentStatus = P.EntityLayer.Enums.DataStatus.Deleted;
			_db.SaveChanges();
		}

		public void DeleteRange(List<T> entities)
		{
			foreach (T item in entities)
			{
				Delete(item);
			}
		}

		public void Destroy(T entity)
		{
			_db.Set<T>().Remove(entity);
			_db.SaveChanges();
		}

		public void DestroyRange(List<T> entities)
		{
			foreach (T item in entities)
			{
				Destroy(item);
			}
		}

		public T Find(int id)
		{
			return _db.Set<T>().Find(id);
		}

		public T FirstOrDefault(Expression<Func<T, bool>> exp)
		{
			return _db.Set<T>().FirstOrDefault(exp);
		}

		public List<T> GetActives()
		{
			return _db.Set<T>().Where(x => x.CurrentStatus != P.EntityLayer.Enums.DataStatus.Deleted).ToList();
		}

		public List<T> GetAll()
		{
			return _db.Set<T>().ToList();
		}

		public List<T> GetDeleteds()
		{
			return _db.Set<T>().Where(x => x.CurrentStatus == P.EntityLayer.Enums.DataStatus.Deleted).ToList();
		}

		public List<T> GetModifieds()
		{
			return _db.Set<T>().Where(x => x.CurrentStatus == P.EntityLayer.Enums.DataStatus.Modified).ToList();
		}

		public object Select(Expression<Func<T, object>> exp)
		{
			return _db.Set<T>().Select(exp);
		}

		public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
		{
			return _db.Set<T>().Where(x => x.CurrentStatus != P.EntityLayer.Enums.DataStatus.Deleted).Select(exp);
		}

		public void Update(T entity)
		{
			entity.ModifiedDate = DateTime.Now;
			entity.CurrentStatus = P.EntityLayer.Enums.DataStatus.Modified;
			T values = Find(entity.ID);
			_db.Entry(values).CurrentValues.SetValues(entity);
			_db.SaveChanges();
		}

		public void UpdateRange(List<T> entities)
		{
			foreach (T item in entities)
			{
				item.ModifiedDate = DateTime.Now;
				item.CurrentStatus = P.EntityLayer.Enums.DataStatus.Modified;
				T values = Find(item.ID);
				_db.Entry(values).CurrentValues.SetValues(item);
				_db.SaveChanges();
			}
		}

		public List<T> Where(Expression<Func<T, bool>> exp)
		{
			return _db.Set<T>().Where(exp).ToList();
		}
	}
}
