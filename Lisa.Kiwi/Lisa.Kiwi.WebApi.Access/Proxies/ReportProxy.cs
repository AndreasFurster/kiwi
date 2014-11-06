﻿using System;
using System.Linq;
using Default;
using Microsoft.OData.Client;

namespace Lisa.Kiwi.WebApi.Access
{
	public class ReportProxy
	{
		public ReportProxy(Uri odataUrl)
		{
			_container = new Container(odataUrl);
		}

		// Get an entire entity set.
		public IQueryable<Report> GetReports(bool getContacts = false)
		{
			if (!getContacts)
			{
				return _container.Report;
			}
			return _container.Report.Expand(r => r.Contacts);
		}

		//Create a new entity
		public void AddReport(Report report)
		{
			_container.AddToReport(report);
			_container.SaveChanges();
		}

	    public void SaveReport(Report report)
	    {
            _container.ChangeState(report, EntityStates.Modified);
	        _container.SaveChanges();
	    }

		private readonly Container _container;
	}
}