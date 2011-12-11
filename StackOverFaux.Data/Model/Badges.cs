using Massive.PostgreSQL;

namespace StackOverFaux.Data.Model
{
	public class Badge : DynamicModel
	{
		public Badge() : base("SoFConnStr")
		{
			PrimaryKeyField  = "badgeid";
			TableName= "badges";
		}

	}

	/*
	public class Badge
	{
		[Key]
		public int BadgeId { get; set; }
		public int UserId { get; set; }
		public string Name { get; set; }
	}

	 */
}


