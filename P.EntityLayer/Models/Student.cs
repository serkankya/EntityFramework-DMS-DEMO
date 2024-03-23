using System;
using System.Collections.Generic;

namespace P.EntityLayer.Models
{
	public class Student : BaseEntity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public decimal PersonalIdentity { get; set; }
		public DateTime BirthDate { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string District { get; set; }
		public string Address { get; set; }
		//public int RoomID { get; set; } 

		//Relation
		public virtual List<Room> Rooms { get; set; }
	}
}
