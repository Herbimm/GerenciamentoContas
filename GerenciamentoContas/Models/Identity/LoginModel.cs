using System.ComponentModel.DataAnnotations;

namespace GerenciamentoContas.Models.Identity
{
    public class LoginModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
