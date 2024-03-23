namespace P.EntityLayer.Models
{
	public class StudentRoomRelation : BaseEntity
	{
		public int RoomID { get; set; }

		public int StudentID { get; set; }

		public virtual Student Student { get; set; }
		public virtual Room Room { get; set; }
	}
}
