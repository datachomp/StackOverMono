using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackOverFaux.Data.Model;

namespace StackOverFaux.Web.Models
{
	public class UserDisplayViewModel
	{
		public dynamic User;
		public IEnumerable<dynamic> Questions;
		public IEnumerable<dynamic> Answers;
		public IEnumerable<dynamic> Badges;
	}
}