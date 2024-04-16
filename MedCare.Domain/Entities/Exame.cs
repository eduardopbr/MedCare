using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedCare.Domain.Entities
{
    [Table("exame")]
    public class Exame : BaseEntity
    {
        [StringLength(50)]
        public required string tipo { get; set; }

        public int pacienteid { get; set; }

        [Column(TypeName = "date")]
        public DateTime data { get; set; }
        [Column(TypeName = "time without time zone")]
        public TimeSpan hora { get; set; }

        public string? resultado { get; set; }

        public Paciente? paciente { get; set; }
    }
}
