﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lisa.Kiwi.Web
{
    public class LocationViewModel
    {
        // TODO: use resource files for display names

        [Required(ErrorMessage = ErrorMessages.RequiredError)]
        [DisplayName("Gebouw *")]
        public string Building { get; set; }
    }
}