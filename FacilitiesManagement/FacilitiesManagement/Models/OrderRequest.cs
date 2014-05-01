using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace FacilitiesManagement.Models
{
    public class OrderRequest
    {
        [Key]
        [Display(Name = "Order Request #")]
        public int OrderRequestId { get; set; }

        [Display(Name = "Requested By")]
        public string RequestedByDomainName { get; set; }
        [Display(Name = "Employee Number")]
        [Required(ErrorMessage = "Employee Number is Required")]
        public string RequestedByEmployeeNum { get; set; }
        [Display(Name = "Phone")]
        public string RequestedByPhone { get; set; }
        [Display(Name = "Email")]
        public string RequestedByEmail { get; set; }

        [Display(Name = "Contact Person")]
        [Required(ErrorMessage = "Contact Person is required")]
        public string ContactPerson { get; set; }
        [Display(Name = "Contact Person Email")]
        public string ContactPersonEmail { get; set; }
        [Display(Name = "Contact Person Phone")]
        [Required(ErrorMessage = "Contact Phone is required")]
        public string ContactPhone { get; set; }
        
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Cost Center is required")]
        public string Department { get; set; }
        [Display(Name = "Budget Year")]
        public string BudgetYear { get; set; }
        [Display(Name = "GL Account")]
        [Required(ErrorMessage = "Select a GL Account")]
        public string GlAccount { get; set; }
        [Display(Name = "Ref#")]
        [RegularExpression(@"^[0-9]{1,10}$", ErrorMessage = "Only numbers are allowed")]
        public string ReferenceNumber { get; set; }
        [Display(Name = "Capital Project Num")]
        public string CapitalProjectNum { get; set; }
        [Display(Name = "Project Location")]
        [Required(ErrorMessage = "Location is required")]
        [RegularExpression(@"^.{1,20}$", ErrorMessage = "Location must be less than 21 characters")]
        public string Location { get; set; }
        public string Comments { get; set; }

        [Display(Name = "Vendor")]
        public string VendorName { get; set; }
        [Display(Name = "Vendor Phone")]
        public string VendorPhone { get; set; }
        [Display(Name = "Vendor Contact")]
        public string VendorContact { get; set; }
        [Display(Name = "Vendor Contact Phone")]
        public string VendorContactPhone { get; set; }
        [Display(Name = "Vendor Fax")]
        public string VendorFax { get; set; }
        [Display(Name = "Vendor Quote Num")]
        public string VendorQuoteNum { get; set; }

        [Display(Name = "Current Order Status")]
        public string Status { get; set; }
        [Display(Name = "Transaction Type")]
        [Required(ErrorMessage = "Select a Transaction Type")]
        public string TransactionType { get; set; }
        [Display(Name = "Required Release Date")]
        public DateTime? RequiredReleaseDate { get; set; }
        [Display(Name = "Estimated Release Date")]
        public DateTime? EstimatedReleaseDate { get; set; }
        [Display(Name = "Submitted On")]
        public DateTime SubmissionDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        
        [Display(Name = "Is Sole Source")]
        public bool? BidHasSoleSource { get; set; }
        [Display(Name = "Bid Project")]
        public bool? BidProject { get; set; }
        

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [Display(Name = "Sub Total")]
        public decimal? SubTotal { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal? Taxes { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal? Shipping { get; set; }
        [Display(Name = "Fuel Charges")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal? FuelCharges { get; set; }
        [Display(Name = "Other Charges")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal? OtherCharges { get; set; }
        [Display(Name = "Total")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal? Total { get; set; }

        //You must put at least 1 or more items below before you can submit this request
        public List<OrderRequestDetail> OrderRequestDetails = new List<OrderRequestDetail>();
    }

    public class OrderRequestDetail
    {

        public int OrderDetailId { get; set; }

        [Required(ErrorMessage = "Order Request ID is required and was not set")]
        public int OrderRequestId { get; set; }

        [Required(ErrorMessage = "Qty is required")]
        [RegularExpression(@"^[0-9]{1,7}$", ErrorMessage = "Only numbers are allowed in the Qty.")]
        public double Qty { get; set; }

        [RegularExpression(@"^.{1,20}$", ErrorMessage = "Unit of Measure must be less than 5 characters")]
        public string UnitOfMeasure { get; set; }

        [Display(Name = "Unit Cost")]
        public decimal? UnitCost { get; set; }

        [Display(Name = "Part Num")]
        public string PartNumber { get; set; }

        [RegularExpression(@"^.{1,500}$", ErrorMessage = "Description must be less than 501 characters")]
        public string Description { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]

        [Display(Name = "Exclude From Total")]
        public bool ExcludeFromTotal { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [NotMapped]
        public decimal SubTotal
        {
            get
            {
                var iQty = (int) Qty;
                var sub = iQty*UnitCost.GetValueOrDefault(0);
                return sub;
            }
        }
    }

    public class GeneralLedgerAccount
    {
        [Key]
        public int GeneralLedgerAccountId { get; set; }
        [Required(ErrorMessage = "Account Number is required")]
        public string AccountNumber { get; set; }
        [Required(ErrorMessage = "Account Name is required")]
        public string AccountName { get; set; }
        [NotMapped]
        public string ExtendedDescription
        {
            get
            {
                var desc = String.Format("{0} - {1}", AccountNumber, AccountName);
                return desc;
            }
        }
    }
}