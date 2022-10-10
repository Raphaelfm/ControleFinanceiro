using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ControleDeFinancas.Models
{
    [Table("Contas_A_Receber")]
    public class ContasReceber
    {
        [Key]
        public int ContaReceberId { get; set; }

        [Required(ErrorMessage = "Identificação deve ser informada.")]
        [DisplayName("Identificação da Conta a Receber")]
        public string ContaReceberIdentificacao { get; set; }

        [DisplayName("Valor da conta R$")]
        [Required(ErrorMessage = "É necessário informar o valor da conta a receber.")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0, 999999999.99, ErrorMessage = "O preço deve estar entre 1 e 999999999,99")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "A previsão de recebimento deve ser preenchida com a data prevista.")]
        [DisplayName("Data Prevista Recebimento")]
        public DateTime PrevisaoRecebimento { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("Observação")]
        [MaxLength(200, ErrorMessage = "Permitido no máximo {1} caracteres.")]
        public string Observacao { get; set; }
    }
}
