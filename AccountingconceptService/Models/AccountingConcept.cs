using System.ComponentModel.DataAnnotations;

namespace AccountingconceptService.Models
{
    public class AccountingConcept
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
