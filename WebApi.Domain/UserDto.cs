using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain
{
    public class UserDto
    {
        
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Compare("Password", ErrorMessage ="Não é igual")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }
        public string NomeCompleto { get; set; }

    }
}
