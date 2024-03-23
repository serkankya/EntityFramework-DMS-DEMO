using P.DataAccessLayer.Context;

namespace BusinessLogicLayer.DesignPatterns.SingletonPattern
{
	public class DBTool
	{
		public DBTool()
		{

		}

		private static AppDbContext _DbInstance;

		public static AppDbContext DbInstance
		{
			get
			{
				if (_DbInstance == null)
				{
					_DbInstance = new AppDbContext();
				}
				return _DbInstance;
			}
		}
	}
}
