using System.ComponentModel.DataAnnotations;

namespace OperationTypeService.Dto
{
    public class OperationTyperequestDto
    {
        [Required]
        public string Name { get; set; }
    }
}
