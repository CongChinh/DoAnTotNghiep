using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class User
    {
        [Key]
        public Int64 Id { get; set; }
        [Required]
        public String Username { get; set; }

        [Required]
        public String Password { get; set; }

        [Required]
        public String Email { get; set; }
        //foreign key
        public int AuthLevelRefId { get; set; }

    }
}
