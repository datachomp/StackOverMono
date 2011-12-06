using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StackOverFaux.Data.Abstract;
using StackOverFaux.Data.Model;
using Massive.PostgreSQL;

namespace StackOverFaux.Data.Concrete
{
	public class SqlUserRepository : IUserRepository
	{
		//SoFConnStr Data = new SoFConnStr();
		public dynamic GetUser(string displayname)
		{
			var table = new User();
			var user = table.Single(where: "userid = @0", args: 91254);
			return user;
		}

		public IEnumerable<dynamic> GetUserQuestions(int userid)
		{
			dynamic table = new Post();
			object[] queryargs = { userid };
			var questions = table.All(where: "owneruserid = @0 and posttypeid = 1", args: queryargs);
			return questions;
		}
		public IEnumerable<dynamic> GetUserAnswers(int userid)
		{
			dynamic table = new Post();
			object[] queryargs = { userid };
			var answers = table.All(where: "owneruserid = @0 and posttypeid = 2", args: queryargs);
			return answers;
		}

		public IEnumerable<dynamic> GetUserPosts(int userid)
		{
			dynamic table = new Post();
			object[] queryargs = { userid };
			var posts = table.All(where: "owneruserid = @0", args: queryargs);
			return posts;
		}



		/*
		public dynamic GetUser(string displayname)
		{
			var user = Data.Users.First(u => u.DisplayName == displayname);//varchar
			return user;
		}

		public IEnumerable<Post> GetUserQuestions(int userid)
		{
			var questions = Data.Posts.Where(p => p.OwnerUserId == userid && p.PostTypeId == 1);
			return questions;
		}
		public IEnumerable<Post> GetUserAnswers(int userid)
		{
			var answers = Data.Posts.Where(p => p.OwnerUserId == userid && p.PostTypeId == 2);
			return answers;
		}

		public IQueryable<Post> GetUserPosts(int userid)
		{
			var posts = Data.Posts.Where(p => p.OwnerUserId == userid);
			return posts;
		}


		public IEnumerable<dynamic> GetUserBadgeCount(int userid)
		{
			var table = new Badge();
			var counts = table.Query("select badgename, count(0) as count from badges where userid = @0", args: userid);

			return counts;
		}
		*/


	}
}
