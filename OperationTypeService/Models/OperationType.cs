using System.ComponentModel.DataAnnotations;

namespace OperationTypeService.Models
{
    public class OperationType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
