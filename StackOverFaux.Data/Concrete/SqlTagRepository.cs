using System.Collections.Generic;
using StackOverFaux.Data.Abstract;
using StackOverFaux.Data.Model;

namespace StackOverFaux.Data.Concrete
{
	public class SqlTagRepository : ITagRepository
	{
		public IEnumerable<dynamic> GetTagList()
		{
			dynamic table = new Tag();
			var tags = table.All();

			return tags;
		}


		//public IQueryable<Post> GetPostsByTag(string tagname)
		public dynamic GetTagCount(string tagname)
		{
			dynamic table = new Post();
			tagname = "'" + tagname + "'";
			object[] queryargs = { tagname };
			//var tags = table.Scalar(@"select count(0) as tagcount from posts WHERE tags like '%@0%", queryargs);
			var tags = table.Scalar(@"select count(0) as tagcount from posts WHERE to_tsvector('english',tags) @@ plainto_tsquery('english', @0)", queryargs);
			//counter = sqlConnection.Query<int>("SELECT Count(0) as PostCount FROM dbo.Posts WHERE FREETEXT(tags, @tagname)", new { tagname = tagname }).Single();
			return tags;
		}


		/*
		SoFConnStr Data = new SoFConnStr();

		public IEnumerable<Tag> GetTagList()
		{
			var tags = from t in Data.Tags
					   orderby t.TagName
					   select t;

			return tags;
		}


		//public IQueryable<Post> GetPostsByTag(string tagname)
		public TagCount GetTagCount(string tagname)
		{
			TagCount counter;
			int count;
			count = Data.Posts.Count(p => p.Tags.Contains(tagname));

			counter = new TagCount { TagName = tagname, CountTag = count };	

			return counter;
		}
		*/
		//This is the Dapper Version
		/*
		public TagCount GetdynPostsByTag(string tagname)
		{
			string connection = ConfigurationManager.ConnectionStrings["SoFConnStr"].ToString();
			int counter;

			using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(connection))
			{
				sqlConnection.Open();
				counter = sqlConnection.Query<int>("SELECT Count(0) as PostCount FROM dbo.Posts WHERE FREETEXT(tags, @tagname)", new { tagname = tagname }).Single();
			}
				TagCount taggy = new TagCount { TagName = tagname, CountTag = counter };
			return taggy;
		} 
*/

			/*  Massive version
			var table = new dynPosts();
			var posts = table.Scalar("SELECT Count(0) as PostCount FROM dbo.Posts WHERE FREETEXT(tags, @0)", args: tagname);
			return Convert.ToInt32(posts);
			 */
	}
}

