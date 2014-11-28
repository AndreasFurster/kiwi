﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lisa.Kiwi.Data
{
	public class Report
	{

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Description { get; set; }

		public DateTimeOffset Created { get; set; }
		public string Location { get; set; }
		public DateTimeOffset Time { get; set; }
		public string Guid { get; set; }
		public string UserAgent { get; set; }
		public bool Hidden { get; set; }

		[MaxLength(45)]
		public string Ip { get; set; }

		public string Type { get; set; }

		public Guid EditToken { get; set; }
	}
}