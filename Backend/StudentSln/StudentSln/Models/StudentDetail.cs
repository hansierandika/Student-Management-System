using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSln.Models
{
    public class StudentDetail
    {
        [Key]
        public int SId { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(10)")]
        public string Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }
        [Required]
        public int Sinhala { get; set; }
        [Required]
        public int Maths { get; set; }
        [Required]
        public int English { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string ContactNo { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
