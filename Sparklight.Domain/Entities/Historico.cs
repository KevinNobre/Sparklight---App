using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sparklight.Domain.Entities
{
    [Table("tb_historico")]
    public class Historico
    {
        [Key]
        [Column("historico_id")]
        public int HistoricoId { get; set; }

        [Required]
        [Column("mes")]
        public int Mes { get; set; }

        [Required]
        [Column("ano")]
        public int Ano { get; set; }

        [Required]
        [Column("consumoMes")]
        public double ConsumoMes { get; set; }

        [Required]
        [Column("custoMes")]
        public double CustoMes { get; set; }

        public Historico()
        { }
    }
}
