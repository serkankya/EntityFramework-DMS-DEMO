using System.Collections.Generic;

namespace P.EntityLayer.Models
{
	public class Block : BaseEntity
	{
		public string BlockName { get; set; }
		public string Address { get; set; }

		//Relation
		public virtual List<Room> Rooms { get; set; }
	}
}
