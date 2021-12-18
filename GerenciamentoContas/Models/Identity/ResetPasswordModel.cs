using System.ComponentModel.DataAnnotations;

namespace GerenciamentoContas.Models.Identity
{
    public class ResetPasswordModel
    {
        public string Token { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password{ get; set; }
        [Compare("Password", ErrorMessage ="")]
        public string ConfirmPassword { get; set; } 
    }
}
