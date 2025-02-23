using System.ComponentModel.DataAnnotations;

namespace startModel.Models
{
    public class Department
    {
        [Key]
        public int Id   { get; set; }

       
        public string Name { get; set; }
        [Required]
        public string Email  { get; set; }

        public string Location { get; set; }

        public string HeadOfDepartment { get; set; }


    }
}
