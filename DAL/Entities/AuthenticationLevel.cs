using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class AuthenticationLevel
    {
        [Key]
        public int AuthId { get; set; }
        [Required]
        public String AuthName { get; set; }
        [ForeignKey("AuthLevelRefId")]
        public ICollection<User> Users { get; set; }
    }
}
