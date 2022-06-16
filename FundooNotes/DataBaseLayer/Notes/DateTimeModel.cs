using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLayer.Notes
{
    public class DateTimeModel
    {
        [Required]
        [RegularExpression("^(3[01]|[12][0-9]|0?[1-9])/(1[0-2]|0?[1-9])/(?:[0-9]{2})?[0-9]{2}$", ErrorMessage = "Enter YYYY-MM-DD format only")]
        public DateTime Remainder { get; set; }
    }
}