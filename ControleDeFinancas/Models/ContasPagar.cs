using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeFinancas.Models
{
    [Table("Contas_A_Pagar")]
    public class ContasPagar
    {
        [Key]
        public int ContaPagarId { get; set; }

        [Required(ErrorMessage = "Identificação deve ser informada.")]
        [DisplayName("Identificação da Conta a Pagar")]
        public string ContaPagarIdentificacao { get; set; }

        [DisplayName("Valor da conta R$")]
        [Required(ErrorMessage = "É necessário informar o valor da conta a pagar.")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0, 999999999.99, ErrorMessage = "O preço deve estar entre 1 e 999999999,99")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "A previsão de pagamento deve ser preenchida com a data prevista.")]
        [DisplayName("Data Prevista Pagamento")]
        public DateTime PrevisaoPagamento { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("Observação")]
        [MaxLength(200, ErrorMessage = "Permitido no máximo {1} caracteres.")]
        public string Observacao { get; set; }
    }
}
