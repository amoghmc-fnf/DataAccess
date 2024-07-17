using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessRecap.Models
{
    [Table("StudentTable")]
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentEmail { get; set; }
        [Required]
        public long ContactNo { get; set; }

        public override string ToString()
        {
            return $"{StudentId} {StudentName} {StudentEmail} {ContactNo}";
        }
    }
}
