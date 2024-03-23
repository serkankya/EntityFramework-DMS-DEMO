using P.EntityLayer.Models;
using P.MappingLayer.Options;
using System.Data.Entity;

namespace P.DataAccessLayer.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext() : base("MyConnection")
		{

		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new StudentRoomRelationMap());
		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Block> Blocks { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<StudentRoomRelation> StudentRoomRelations { get; set; }
	}
}
