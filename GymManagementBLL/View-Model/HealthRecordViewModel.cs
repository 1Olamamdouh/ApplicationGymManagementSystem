using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.View_Model
{
    internal class HealthRecordViewModel
    {

        //The health record of a gym member includes the following properties:

        [Required(ErrorMessage = "Height is required")]
        [Range(0.1, 300, ErrorMessage = "Height must be between 0.1 cm and 300 cm")]
        public decimal Height { get; set; } // in centimeters

        [Required(ErrorMessage = "Weight is required")]
        [Range(1, 350, ErrorMessage = "Weight must be between 1 kg and 350 kg")]
        public decimal Weight { get; set; } // in kilograms

        [Required(ErrorMessage = "Bool Type Is Required")]
        [StringLength(3, ErrorMessage = "Blood Type is max 3")]
        public string Booltype { get; set; } = null!; // e.g., A+, O-, etc.
        public string? Notes { get; set; } // Optional additional notes

    }
}
