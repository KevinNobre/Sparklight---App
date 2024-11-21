using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sparklight.Domain.Entities
{
    [Table("TB_APARELHO")]
    public class Aparelho
    {
        [Key]
        [Column("APARELHO_ID")] // Nome da coluna conforme a tabela
        public int AparelhoId { get; set; }

        [Required]
        [MaxLength(55)] // Alinhado ao tamanho máximo da coluna VARCHAR2(55 BYTE)
        [Column("NOME")]
        public string Nome { get; set; }

        [Required]
        [Column("POTENCIA", TypeName = "NUMBER(10, 2)")] // Alinhado ao tipo NUMBER(10,2)
        public decimal Potencia { get; set; } // Usando `decimal` para valores numéricos precisos

        [Required]
        [Column("TEMPO", TypeName = "NUMBER(10, 2)")] // Alinhado ao tipo NUMBER(10,2)
        public decimal Tempo { get; set; } // Usando `decimal` para valores numéricos precisos

        [Required]
        [MaxLength(45)] // Alinhado ao tamanho máximo da coluna VARCHAR2(45 BYTE)
        [Column("PERIODO")]
        public string Periodo { get; set; }

        [Required]
        [ForeignKey("Usuario")] // Indica o relacionamento com a tabela `tb_usuario`
        [Column("TB_USUARIO_USUARIO_ID")]
        public int UsuarioId { get; set; } // Alinhado à coluna `tb_usuario_usuario_id`

        // Relacionamento com a entidade Usuário (opcional, mas recomendado)
        public virtual Usuario Usuario { get; set; }

        public Aparelho()
        {
        }
    }
}
