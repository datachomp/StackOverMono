using System;
using System.Linq;
using StackOverFaux.Data.Abstract;
using StackOverFaux.Data.Model;
using System.Runtime.Caching;
using System.Configuration;
using Dapper;
using System.Collections.Generic;

namespace StackOverFaux.Data.Concrete
{
	public class SqlPostRepository : IPostRepository
	{
		public IEnumerable<dynamic> GetRecentPosts()
		{
			dynamic table = new Post();
			var recentposts = table.Query(@"select p.postid, p.answercount,p.viewcount,p.title,p.tags,u.userid,u.displayname,u.reputation 
							from posts p inner join users u on p.owneruserid = u.userid 
							where p.posttypeid = 1
							order by p.creationdate desc
							limit 20");

							  //yep, making assumptions here with the post types. saving joins though!
							  //join pt in posts.PostTypes on p.PostType.PostTypeId equals pt.PostTypeId
			return recentposts;
		}


		public IEnumerable<dynamic> GetHotPosts()
		{
			//The dataset isn't recent, so we get to fake some dates!
			DateTime WhenItAllBegins = new DateTime(2011, 3, 25, 0, 0, 0);
			dynamic table = new Post();
			var hotposts = table.Single(@"select p.postid, p.answercount,p.viewcount,p.title,p.tags,u.userid,u.displayname,u.reputation 
							from posts p inner join users u on p.owneruserid = u.userid 
							where p.posttypeid = 1 and p.creationdate >= @0
							order by p.viewcount desc
							limit 20", args: WhenItAllBegins);
			
			return hotposts ;
		}


		public IEnumerable<dynamic> GetMostRecentPostsCache()
		{
			MemoryCache cache = MemoryCache.Default;
			string key = "recentposts";

			IEnumerable<dynamic> posts;

			if (!cache.Contains(key))
			{

				dynamic table = new Post();
				 posts = table.Query(@"select p.postid, p.answercount,p.viewcount,p.title,p.tags,u.userid,u.displayname,u.reputation 
							from posts p inner join users u on p.owneruserid = u.userid 
							where p.posttypeid = 1 
							order by p.creationdate desc
							limit 20");

				CacheItemPolicy policy = new CacheItemPolicy();
				policy.SlidingExpiration = new TimeSpan(0, 0, 0, 45, 0);
				cache.Set(key, posts, policy);

				return posts;
			}
			else
			{
				posts = cache.Get(key) as IEnumerable<dynamic>;
				return posts;
			}
		}

		/*
		SoFConnStr Data = new SoFConnStr();

		public IQueryable<FrontPage> GetRecentPosts()
		{
			

			var recentposts = from p in Data.Posts
							  join u in Data.Users on p.OwnerUserId equals u.UserId

							  //yep, making assumptions here with the post types. saving joins though!
							  //join pt in posts.PostTypes on p.PostType.PostTypeId equals pt.PostTypeId
							  where p.PostTypeId == 1
							  orderby p.CreationDate descending
							  select new FrontPage
							  {
								  PostId = p.PostId,
								  AnswerCount = p.AnswerCount,
								  ViewCount = p.ViewCount,
								  Title = p.Title,
								  Tags = p.Tags,
								  UserId = u.UserId,
								  DisplayName = u.DisplayName,
								  Reputation = u.Reputation
							  };
			
			return recentposts.Take(20).AsQueryable();
		}


		public IQueryable<FrontPage> GetHotPosts()
		{
			//The dataset isn't recent, so we get to fake some dates!
			DateTime WhenItAllBegins = new DateTime(2011, 3, 25, 0, 0, 0);
			var recentposts = from p in Data.Posts
							  join u in Data.Users on p.OwnerUserId equals u.UserId
							  //where p.PostTypeId == 1 && p.CreationDate >= DateTime.Parse("03/20/2011").Date
							  where p.PostTypeId == 1 && p.CreationDate >= WhenItAllBegins
							  //where p.PostTypeId ==1 && p.CreationDate >= DateTime.Today.AddDays(-7);
							  orderby p.ViewCount descending
							  //select p;
							  select new FrontPage {
							   PostId = p.PostId, AnswerCount = p.AnswerCount, ViewCount= p.ViewCount, Title= p.Title , Tags= p.Tags
								,UserId= u.UserId, DisplayName= u.DisplayName, Reputation= u.Reputation};
			
			
			return recentposts.Take(20).AsQueryable(); ;
		}


		public IQueryable<FrontPage> GetMostRecentPostsCache()
		{
			MemoryCache cache = MemoryCache.Default;
			string key = "recentposts";

			string connection = ConfigurationManager.ConnectionStrings["SoFConnStr"].ToString();
			IQueryable<FrontPage> posts;

			if (!cache.Contains(key))
			{

				using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(connection))
				{
					sqlConnection.Open();
					string query = "SELECT TOP 20 p.PostId, p.AnswerCount, P.ViewCount, P.Title, P.Tags, u.UserId, U.DisplayName, u.Reputation"
									+ " FROM dbo.Posts P INNER JOIN dbo.Users U ON P.OwnerUserId = U.UserId"
									+ " WHERE p.PostTypeId = 1 AND p.CreationDate >= '3/28/2011'"
									+ " ORDER BY p.CreationDate Desc";
					posts = sqlConnection.Query<FrontPage>(query).AsQueryable();
				}

				CacheItemPolicy policy = new CacheItemPolicy();
				policy.SlidingExpiration = new TimeSpan(0, 0, 0, 45, 0);
				cache.Set(key, posts, policy);

				return posts;
			}
			else
			{
				posts = cache.Get(key) as IQueryable<FrontPage>;
				return posts;
			}
		}
		*/
	}
}
