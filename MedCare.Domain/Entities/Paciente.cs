using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedCare.Domain.Entities
{
    [Table("paciente")]
    public class Paciente : BaseEntity
    {
        [StringLength(50)]
        public string nome { get; set; } = null!;
        [StringLength(40)]
        public string cpf { get; set; } = null!;
        [StringLength(20)]
        public string sexo { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime datanascimento { get; set; }

        [StringLength(200)]
        public string endereco { get; set; } = null!;

        [StringLength(30)]
        public string celular { get; set; } = null!;

        [StringLength(200)]
        public string email { get; set; } = null!;
    }
}
