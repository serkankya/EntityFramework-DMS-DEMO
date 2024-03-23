using P.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.PresentationLayerWF.ViewModels
{
	public class BlockVM
	{
        public int IDVM { get; set; }
		public string BlockNameVM { get; set; }
		public string AddressVM { get; set; }


		//Relation
		public virtual List<Room> RoomsVM { get; set; }

		public override string ToString()
		{
			return BlockNameVM;
		}
	}
}
