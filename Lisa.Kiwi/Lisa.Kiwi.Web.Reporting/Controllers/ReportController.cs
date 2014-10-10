﻿using System.Collections.Generic;
using System.Web.Mvc;
using Lisa.Kiwi.Web.Reporting.Models;
using Lisa.Kiwi.Tools;
using System;

namespace Lisa.Kiwi.Web.Reporting.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private OriginalReport GetReport()
        {
            if (Session["userReport"] == null)
            {
                Session["userReport"] = new OriginalReport();
            }
            return (OriginalReport)Session["userRaport"];
        }

        public ActionResult Type()
        {
            var types = new string[]
            {
                "Drugs",
                "Overlast",
                "Voertuigen",
                "Inbraak",
                "Diefstal",
                "Intimidatie",
                "Pesten",
                "Digitaal grensoverschrijdend gedrag",
                "Etc"
            };

            ViewBag.ReportTypes = new SelectList(types);

            return View();
        }

        [HttpPost]
        public ActionResult Type(string reportType)
        {
            if (reportType != null)
            {
                if (ModelState.IsValid)
                {
                    OriginalReport type = GetReport();

                    return RedirectToAction("Details", "Report");
                }
            }
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(OriginalReport data, string reportType)
        {
            ViewBag.ReportType = reportType;

            if (ModelState.IsValid)
            {
                string guid = Guid.NewGuid().ToString();

                OriginalReport report = new OriginalReport();
                report.Location = data.Location;
                report.Time = data.Time;
                report.Description = data.Description;
                report.Type = reportType;
                report.Guid = guid;

                return RedirectToAction("ContactDetails", "Report");
            }

            return View();
        }

        public ActionResult ContactDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contactdetails(Contact data, string guid)
        {
            if (ModelState.IsValid)
            {
                Contact contact = new Contact();
                contact.Name = data.Name;
                contact.PhoneNumber = data.PhoneNumber;
                contact.Email = data.Email;
                contact.StudentNumber = data.StudentNumber;
                return RedirectToAction("Confirmed", "Report");
            }

            return View();
        }

        public ActionResult Confirmed()
        {
            return View();
        }
    }
}