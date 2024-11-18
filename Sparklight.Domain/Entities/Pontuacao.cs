using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sparklight.Domain.Entities
{
    [Table("tb_pontuacao")]
    public class Pontuacao
    {
        [Key]
        [Column("pontuacao_id")]
        public int PontuacaoId { get; set; }

        [Required]
        [Column("pontos")]
        public int Pontos { get; set; }

        [ForeignKey("tb_usuario")]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Pontuacao()
        { }

    }
}
