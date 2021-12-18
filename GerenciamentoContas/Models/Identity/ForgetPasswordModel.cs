using System.ComponentModel.DataAnnotations;

namespace GerenciamentoContas.Models.Identity
{
    public class ForgetPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
