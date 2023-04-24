using System.ComponentModel.DataAnnotations;

namespace CsStatTracker.Models
{
    public class Members
    {
        /// <summary>
        /// The username that the member registers with.
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// The password that the member registers with.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// The email registered to the members account.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// The phone number that the member registers with.
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// The member ID that is used to organize members.
        /// </summary>
        [Key]
        public int MemberID { get; set; }
    }
    
    /// <summary>
    /// ViewModel To allow a register page to be linked with the members controller.
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// Email is required and the maximum characters can be up to 100.
        /// The only current validation is that the email must require an @ sign.
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        /// <summary>
        /// ConfirmEmail allows for the 2nd box on the registration page to match
        /// the initial email registered with to confirm that the email provided is correct.
        /// </summary>
        [Required]
        [Compare(nameof(Email))]
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }
        /// <summary>
        /// Password is required for the user to register and must be at least 6 characters
        /// but no more than 75. The password will remain hidden until the user presses the show
        /// password button that is usually provided by the browser.
        /// </summary>
        [Required]
        [StringLength(75, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        /// <summary>
        /// Works the same as ConfirmEmail and allows the user to confirm their password before
        /// sending it to the database.
        /// </summary>
        [Required]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
    /// <summary>
    /// ViewModel to allow a login page to be linked with the members controller.
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// The required email address that the user registered with on the registration page.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        /// <summary>
        /// The required password that the user registered with on the register page.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
