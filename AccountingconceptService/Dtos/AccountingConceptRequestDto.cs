using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AccountingconceptService.Dtos
{
    public class AccountingConceptRequestDto
    {
        [Required]
        public string Name { get; set; }
    }
}
