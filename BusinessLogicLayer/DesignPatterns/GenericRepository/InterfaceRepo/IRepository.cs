using P.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLogicLayer.DesignPatterns.GenericRepository.InterfaceRepo
{
	public interface IRepository<T> where T : BaseEntity
	{
		//List
		List<T> GetAll();
		List<T> GetActives();
		List<T> GetModifieds();
		List<T> GetDeleteds();

		//CRUD
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		void Destroy(T entity);

		void AddRange(List<T> entities);
		void UpdateRange(List<T> entities);
		void DeleteRange(List<T> entities);
		void DestroyRange(List<T> entities);

		//Find
		T Find(int id);

		//LINQ
		List<T> Where(Expression<Func<T, bool>> exp);
		object Select(Expression<Func<T, object>> exp);
		IQueryable<X> Select<X>(Expression<Func<T, X>> exp);
		bool Any(Expression<Func<T, bool>> exp);
		T FirstOrDefault(Expression<Func<T, bool>> exp);

	}
}
