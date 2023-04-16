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
}
