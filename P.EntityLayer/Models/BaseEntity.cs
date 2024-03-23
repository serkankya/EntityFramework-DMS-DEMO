using P.EntityLayer.Enums;
using System;

namespace P.EntityLayer.Models
{
	public abstract class BaseEntity
	{
		public int ID { get; set; }
		public DateTime InsertedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public DataStatus CurrentStatus { get; set; }

		public BaseEntity()
		{
			InsertedDate = DateTime.Now;
			CurrentStatus = DataStatus.Inserted;
		}
	}
}
