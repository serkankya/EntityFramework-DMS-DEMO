using P.EntityLayer.Models;

namespace P.MappingLayer.Options
{
	public class StudentRoomRelationMap : BaseMap<StudentRoomRelation>
	{
		public StudentRoomRelationMap()
		{
			Ignore(x => x.ID);
			HasKey(x => new
			{
				x.StudentID,
				x.RoomID
			});
		}
	}
}
