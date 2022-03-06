using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)] 
        public string? Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Surname { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public DateTime EnrollmentYear { get; set; }
        
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Adress { get; set; }

        public bool IsElder { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
