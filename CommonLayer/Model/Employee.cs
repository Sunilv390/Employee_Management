using System.ComponentModel.DataAnnotations;

namespace CommonLayer.Model
{
    public class Employee
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the salary.
        /// </summary>
        /// <value>
        /// The salary.
        /// </value>
        [Required]
        [RegularExpression(@"^{5}[0-9]*$")]
        public double Salary { get; set; }

        /// <summary>
        /// Gets or sets the designation.
        /// </summary>
        /// <value>
        /// The designation.
        /// </value>
        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string Designation { get; set; }

        /// <summary>
        /// Gets or sets the experience.
        /// </summary>
        /// <value>
        /// The experience.
        /// </value>
        [Required]
        [RegularExpression(@"^{2}[0-9]*$")]
        public double Experience { get; set; }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>
        /// The department.
        /// </value>
        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string Department { get; set; }

        /// <summary>
        /// Gets or sets the contact number.
        /// </summary>
        /// <value>
        /// The contact number.
        /// </value>
        [Required]
        [Phone]
        public string ContactNumber { get; set; }
    }
}

