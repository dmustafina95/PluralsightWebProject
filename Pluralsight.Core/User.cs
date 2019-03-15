using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pluralsight.Core
{
    public class User
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(255)]
        public string LastName { get; set; }
        [Required]
        public string Dob { get; set; }
    }
}
