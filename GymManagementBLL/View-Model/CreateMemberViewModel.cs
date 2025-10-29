using GymManagementDAL.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.View_Model
{
    internal class CreateMemberViewModel 
    {
        [Required(ErrorMessage = " Name is Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 ")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain letters or spaces only ")]
        public string Name { get; set; } = null!;
        
        
        [Required(ErrorMessage ="Email is Required")]
        [EmailAddress (ErrorMessage ="Invalid Email format")] //App to validate email format
        [DataType(DataType.EmailAddress)] //UI Hint for email input
        [StringLength(100, MinimumLength = 5, ErrorMessage ="Email must be between 5 and 100")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Phone is Required")]
        [Phone (ErrorMessage = " Invalid phone formate")]
        [RegularExpression(@"^(010|011|012|015)\d{8}$")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage ="DataOfBirth is Required")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage ="Building Number is Required")]
        [Range(1,9000, ErrorMessage ="Building Number between 1 and 9000")]
        public int BuildingNumber { get; set; }

        [Required(ErrorMessage = "City is Required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Email must be between 2 and 30")]
        public string City { get; set; }= null!;


        [Required(ErrorMessage = "Street is Required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Email must be between 2 and 30")]
        public string street { get; set; } = null!;


        [Required(ErrorMessage = "Gender is Required")]
        public Gender Gender { get; set; }


        [Required (ErrorMessage = "Health Reacord is required ")]
        public HealthRecordViewModel HealthRecord { get; set; } = null!; // Navigation property to HealthRecordViewModel




    }

}
