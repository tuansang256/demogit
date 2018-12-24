using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace General
{
    [DataContract]
    public class Member
    {

        [DataMember]
        [Key]
        public int ID { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Name can not left blank")]
        [StringLength(50, ErrorMessage = "Name is between 3-30 characters")]
        public string Name { get; set; }

        [DataMember]
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Password maximum length is 30 characters")]
        public string Password { get; set; }

        [DataMember]
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Email maximum length is 30 characters")]
        public string Email { get; set; }

        [DataMember]
        [Required]
        public bool Gender { get; set; }
    }
}