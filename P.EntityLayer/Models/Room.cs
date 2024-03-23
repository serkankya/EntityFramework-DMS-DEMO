using System.Collections.Generic;

namespace P.EntityLayer.Models
{
	public class Room : BaseEntity
	{
		public int RoomNumber { get; set; }
		public int BlockID { get; set; }

		//Relation
		public virtual Block Block { get; set; }
		public virtual List<Student> Students { get; set; }
	}
}
