using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framework.Accounting.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        [Required(ErrorMessage = "Account Number is required")]
        public string Number { get; set; }
        [Required(ErrorMessage = "Account Name is required")]
        public string Name { get; set; }
        [NotMapped]
        public string Description
        {
            get
            {
                var desc = String.Format("{0} - {1}", Number, Name);
                return desc;
            }
        }
    }
}