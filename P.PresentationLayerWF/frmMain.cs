using BusinessLogicLayer.DesignPatterns.GenericRepository.ConcreteRepo;
using P.EntityLayer.Models;
using P.PresentationLayerWF.ViewModels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace P.PresentationLayerWF
{
	public partial class frmMain : Form
	{
		BlockRepo _blockRepo;
		RoomRepo _roomRepo;
		StudentRepo _studentRepo;
		StudentRoomRelationRepo _studentRelationRepo;
		public frmMain()
		{
			InitializeComponent();
			_blockRepo = new BlockRepo();
			_roomRepo = new RoomRepo();
			_studentRepo = new StudentRepo();
			_studentRelationRepo = new StudentRoomRelationRepo();
		}

		void ListBlock()
		{
			cmbRoomBlock.DataSource = _blockRepo.Select(x => new BlockVM
			{
				IDVM = x.ID,
				AddressVM = x.Address,
				BlockNameVM = x.BlockName,
				RoomsVM = x.Rooms,
			}).ToList();

			cmbRoomBlock.DisplayMember = "BlockNameVM";
			cmbRoomBlock.ValueMember = "IDVM";
		}

		void ListRoom()
		{
			cmbStudentRoom.DataSource = _roomRepo.Select(x => new RoomVM
			{
				IDVM = x.ID,
				BlockIDVM = x.BlockID,
				BlockVM = x.Block,
				RoomNumberVM = x.RoomNumber,
				StudentsVM = x.Students
			}).ToList();

			cmbStudentRoom.DisplayMember = "RoomNumberVM";
			cmbStudentRoom.ValueMember = "IDVM";
		}

		private void btnAddBlock_Click(object sender, EventArgs e)
		{
			Block _b = new Block();
			_b.BlockName = txtBlockName.Text;
			_b.Address = txtBlockAddress.Text;

			_blockRepo.Add(_b);
			MessageBox.Show("Blok eklendi");
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			ListBlock();
			ListRoom();
		}

		private void btnAddRoom_Click(object sender, EventArgs e)
		{
			Room _r = new Room();
			_r.RoomNumber = Convert.ToInt32(txtRoomNumber.Text);
			_r.BlockID = Convert.ToInt32(cmbRoomBlock.SelectedValue);

			_roomRepo.Add(_r);
			MessageBox.Show("Oda eklendi");
		}

		private void btnAddStudent_Click(object sender, EventArgs e)
		{
			Student _s = new Student();
			_s.FirstName = txtStudentFirstName.Text;
			_s.LastName = txtStudentLastName.Text;
			_s.PersonalIdentity = Convert.ToDecimal(txtStudentIdentity.Text);
			_s.BirthDate = dateStudentBirthDate.Value;
			_s.Country = txtStudentCountry.Text;
			_s.City = txtStudentCity.Text;
			_s.District = txtStudentDistrict.Text;
			_s.Address = txtStudentAddress.Text;

			_studentRepo.Add(_s);

			StudentRoomRelation _srr = new StudentRoomRelation();
			_srr.StudentID = _s.ID;
			_srr.RoomID = Convert.ToInt32(cmbStudentRoom.SelectedValue);

			_studentRelationRepo.Add(_srr);

			MessageBox.Show("Öğrenci eklendi");
		}
	}
}
