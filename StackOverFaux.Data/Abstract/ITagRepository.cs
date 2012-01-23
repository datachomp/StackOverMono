using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StackOverFaux.Data.Model;

namespace StackOverFaux.Data.Abstract
{
    public interface ITagRepository
    {
        IEnumerable<dynamic> GetTagList();
        //IQueryable<Post> GetPostsByTag(string tagid);
		dynamic GetTagCount(string tagname);
		//TagCount GetdynPostsByTag(string tagname);
        IEnumerable<dynamic> GetQuickTagList();        
    }
}
