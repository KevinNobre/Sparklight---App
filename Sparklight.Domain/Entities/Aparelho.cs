using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sparklight.Domain.Entities
{
    [Table("tb_aparelho")]
    public class Aparelho
    {
        [Key]
        [Column("imagem_id")]
        public int AparelhoId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("nome")]
        public string Nome { get; set; }

        [Required]
        [Column("potencia")]
        public double Potencia { get; set; }

        [Required]
        [Column("tempo")]
        public int Tempo { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("periodo")]
        public string Periodo { get; set; }

        [ForeignKey("tb_usuario")]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Aparelho()
        { }

    }
}
