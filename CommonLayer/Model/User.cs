using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string Name { get; set; }

        [Required]
        [Phone]
        [RegularExpression(@"^[7-9]{1}[0-9]{9}$")]
        public string Contact { get; set; }
    }
}
