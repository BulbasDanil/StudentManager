using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Models
{
    public class Group
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Name { get; set; }


        public Faculty Faculty { get; set; }
        public int FacultyId { get; set; }

        
        public virtual ICollection<Student>? Students { get; set; }

    }
}
