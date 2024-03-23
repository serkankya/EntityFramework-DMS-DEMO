using P.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.PresentationLayerWF.ViewModels
{
	public class RoomVM
	{
        public int IDVM { get; set; }
        public int RoomNumberVM { get; set; }
		public int BlockIDVM { get; set; }

		//Relation
		public virtual Block BlockVM { get; set; }
		public virtual List<Student> StudentsVM { get; set; }

		public override string ToString()
		{
			return RoomNumberVM.ToString();
		}
	}
}
