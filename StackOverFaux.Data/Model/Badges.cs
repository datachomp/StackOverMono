using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
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


