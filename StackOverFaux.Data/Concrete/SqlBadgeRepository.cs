using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StackOverFaux.Data.Abstract;
using StackOverFaux.Data.Model;

namespace StackOverFaux.Data.Concrete
{
	public class SqlBadgeRepository : IBadgeRepository
	{
		//SoFConnStr Data = new SoFConnStr();

		public IEnumerable<dynamic> GetAllBadges()
		{
			dynamic table =  new Badge();
			var badges = table.All();
			
			return badges;
		}

		public IEnumerable<dynamic> GetBadgesByUserID(int userid)
		{

			dynamic table = new Badge();
			object[] queryargs = { userid };
			var badges = table.All(where: "userid = @0", args: queryargs);

			return badges;
			
		}

		public IEnumerable<dynamic> GetAllBadgeCounts()
		{
			var table = new Badge();
			object[] queryargs = { 91254 };
			var counts = table.Query("select name as badgename, count(0) as badgecount from badges where userid = @0 group by badgename", args: queryargs);

			return counts;
		}

		/*
		//public IEnumerable<Badge> GetAllBadges()
		public IQueryable<Badge> GetAllBadges()
		{
			var badges = from b in Data.Badges
						 //join c in Data.Users on b.UserId equals c.UserId
						 select b;

			return badges;
		}

		public IEnumerable<Badge> GetBadgesByUserId(int userid)
		{
			var badges = from b in Data.Badges
						 join c in Data.Users on b.UserId equals c.UserId
						 where b.UserId == userid
						 select b;
			return badges;
		}*/
	}
}
