using System.ComponentModel.DataAnnotations;

namespace ANC.Web.UI.Loja.Models
{
    public class AdicaoDeCliente
    {
        [Required(ErrorMessage="O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage="O e-mail é obrigatório."), EmailAddress(ErrorMessage="Formato do e-mail inválido.")]
        public string Email { get; set; }

        public string Foto { get; set; }
    }
}