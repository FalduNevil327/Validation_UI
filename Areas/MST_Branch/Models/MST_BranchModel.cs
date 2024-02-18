using System.ComponentModel.DataAnnotations;

namespace Validation_UI.Areas.LOC_Branch.Models
{
    public class MST_BranchModel
    {
        public int BranchID { get; set; }
        [Required]
        public string? BranchName { get; set; }
        [Required]
        public string? BranchCode { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

    }
    public class MST_BranchDropDownModel
    {
        public int BranchID { get; set; }
        public string? BranchName { get; set; }
    }
}
