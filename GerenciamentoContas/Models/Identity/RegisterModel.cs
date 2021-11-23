using System.ComponentModel.DataAnnotations;

namespace GerenciamentoContas.Models.Identity
{
    public class RegisterModel
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfimPassword { get; set; }
    }
}
