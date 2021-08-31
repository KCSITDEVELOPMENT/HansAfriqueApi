using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Dto
{
        public class UserRegisterDto
        {
            [Required]
            public string Username { get; set; }

            [Required]
            [StringLength(8, MinimumLength = 4, ErrorMessage ="You Must Specify Password between 4 to 8 Characters")]
            public string Password { get; set; }
        }
    
}
