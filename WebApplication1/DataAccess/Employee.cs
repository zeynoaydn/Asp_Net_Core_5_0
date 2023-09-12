using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DataAccess
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
