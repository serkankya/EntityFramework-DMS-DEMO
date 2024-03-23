using P.EntityLayer.Models;
using System.Data.Entity.ModelConfiguration;

namespace P.MappingLayer.Options
{
	public class BaseMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
	{
		public BaseMap()
		{

		}
	}
}
