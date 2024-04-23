using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedCare.Domain.Entities
{
    [Table("consulta")]
    public class Consulta : BaseEntity
    {
        public int pacienteid { get; set; }
        [Column(TypeName = "date")]
        public DateTime datanasc {  get; set; }
        public int funcionarioid { get; set; }
        public int registro { get; set; }
        [StringLength(100)]
        public string especialidade { get; set; } = null!;

        public string diagnostico { get; set; } = null!;

        [StringLength(100)]
        public string? examesrelacionados { get; set; }
    }
}
