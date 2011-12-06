using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StackOverFaux.Data.Model;

namespace StackOverFaux.Data.Abstract
{
    public interface IUserRepository
    {
        dynamic GetUser(string displayname);
        IEnumerable<dynamic> GetUserQuestions(int userid);
        IEnumerable<dynamic> GetUserAnswers(int userid);
        IEnumerable<dynamic> GetUserPosts(int userid);


        //IEnumerable<dynamic> GetUserBadgeCount(int userid);
    }
}
