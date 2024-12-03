using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Expence_Tracker.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        // CategoryId 
        // Here CategoryId is used as a foreign key
        [Range(1, int.MaxValue,ErrorMessage = "Please Select a Category.")]
        public int CategoryId { get; set; }

        // Navigation Property for define a foreign key 
        public Category? Category { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than zero.")]
        public int Amount { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string? Note { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [NotMapped]
        public string CategoryTitleWithIcon
        {
            get
            {
                return Category == null ? "" : Category.Icon + " " + Category.Name;
            }
        }


        [NotMapped]
        public string FormattedAmount
        {
            get
            {
                return ((Category == null || Category.Type == "Expense") ? "-" : "+") + Amount.ToString("c0", new CultureInfo("hi-IN"));
            }
        }
    }
}
