﻿using System;
using System.Linq;
using System.Web.Mvc;
using System.Reflection;
using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json;

namespace Lisa.Kiwi.Web.Controllers
{
    public class ResourcesController : Controller
    {
        public ActionResult Dutch()
        {
            var resourcesTypes = GetAllResourceTypes();
            IDictionary<string, object> result = new ExpandoObject();

            foreach (var resource in resourcesTypes)
            {
                IDictionary<string, object> translations = new ExpandoObject();

                foreach (var translation in resource.GetProperties())
                {
                    translations.Add(translation.Name, translation.Name);
                }

                result.Add(resource.Name, translations);
            }

            
            return Content(JsonConvert.SerializeObject(result), "application/json");     
        }

        private Type[] GetAllResourceTypes()
        {
            return Assembly.GetExecutingAssembly().GetTypes().Where(t => string.Equals(t.Namespace, "Resources", StringComparison.Ordinal)).ToArray();
        }
    }
}