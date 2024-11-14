using System.ComponentModel.DataAnnotations;

namespace ECommerse_App.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
