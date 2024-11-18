using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sparklight.Domain.Entities
{
    [Table("tb_usuario")]
    public class Usuario
    {
        [Key]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("nome")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("sobrenome")]
        public string Sobrenome { get; set; }

        [Required]
        [EmailAddress]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(8)]
        [Column("cep")]
        public string CEP { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("estado")]
        public string Estado { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("cidade")]
        public string Cidade { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("genero")]
        public string Genero { get; set; }

        [Required]
        [Column("idade")]
        public int Idade { get; set; }

        [Required]
        [MaxLength(15)]
        [Column("contato")]
        public string Contato { get; set; }

        [Required]
        [MinLength(6)]
        [Column("senha")]
        public string Senha { get; set; }

        public Usuario()
        { }

    }
}
