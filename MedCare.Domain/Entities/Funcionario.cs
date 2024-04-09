using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Domain.Entities
{
    [Table("funcionario")]
    public class Funcionario : BaseEntity
    {
        [StringLength(50)]
        public string nome { get; set; } = null!;
        [StringLength(40)]
        public string cpf { get; set; } = null!;

        [StringLength(20)]
        public string sexo { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime datanascimento { get; set; }

        [StringLength(50)]
        public string cargo { get; set; } = null!;
        [StringLength(100)]
        public string? registr_profissional { get; set; }

        [StringLength(100)]
        public string? especialidade { get; set; }

        [StringLength(200)]
        public string endereco { get; set; } = null!;

        [StringLength(30)]
        public string celular { get; set; } = null!;

        [StringLength(200)]
        public string email { get; set; } = null!;
    }
}
