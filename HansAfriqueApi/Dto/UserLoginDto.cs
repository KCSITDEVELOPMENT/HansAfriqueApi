using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Dto
{
        public class UserLoginDto
        {
        [Required]
        public string UsernameLog { get; set; }
        [Required]
        public string PasswordLog { get; set; }

    }
    
}
