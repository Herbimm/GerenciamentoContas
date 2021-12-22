using System.ComponentModel.DataAnnotations;

namespace GerenciamentoContas.Models.Identity
{
    public class TwoFactorModel
    {
        [Required]
        public string Token { get; set; }
    }
}
