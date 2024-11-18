using Sparklight.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sparklight.Domain.Entities
{
    [Table("tb_item")]
    public class Item
    {
        [Key]
        [Column("item_id")]
        public int ItemId { get; set; }

        [Required]
        [Column("quantidade")]
        public int Quantidade { get; set; }

        [Required]
        [Column("consumoMes")]
        public double ConsumoMes { get; set; }

        [Required]
        [Column("custoMensal")]
        public double CustoMensal { get; set; }

        [ForeignKey("tb_aparelho")]
        [Column("imagem_id")]
        public int AparelhoId { get; set; }
        public Aparelho Aparelho { get; set; }

        public Item()
        { }
    }
}
