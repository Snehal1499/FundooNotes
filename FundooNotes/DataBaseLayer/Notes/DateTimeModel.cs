using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLayer.Notes
{
    public class DateTimeModel
    {
        [Required]
        [RegularExpression(@"^d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$", ErrorMessage = "Enter Valid Date")]
        public DateTime Reminder { get; set; }
    }
}
