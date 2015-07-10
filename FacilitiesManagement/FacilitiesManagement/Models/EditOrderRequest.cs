using System;
using System.ComponentModel.DataAnnotations;

namespace FacilitiesManagement.Models
{
    public class EditOrderRequest
    {
        [Key]
        [Display(Name = "Order Request #")]
        public int OrderRequestId { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Cost Center is required")]
        public string Department { get; set; }
        
        [Display(Name = "Budget Year")]
        public string BudgetYear { get; set; }

        [Display(Name = "Ref#")]
        public string ReferenceNumber { get; set; }

        public DateTime? LastUpdate { get; set; }
    }
}