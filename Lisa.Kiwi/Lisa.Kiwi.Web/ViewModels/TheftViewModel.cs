﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lisa.Kiwi.Web
{
    public class TheftViewModel
    {
        [Required(ErrorMessage = ErrorMessages.RequiredError)]
        [DisplayName("Wat is er gestolen?")]
        public string StolenObject { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredError)]
        [DisplayName("Hoe laat is het gestolen?")]
        public DateTime DateOfTheft { get; set; }
    }
}