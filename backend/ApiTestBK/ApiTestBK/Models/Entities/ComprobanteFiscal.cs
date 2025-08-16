using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTestBK.Models.Entities
{
    public class ComprobanteFiscal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string RncCedula { get; set; }
        public string? NCF { get; set; }
        public decimal Monto { get; set; }
        public decimal Itbis18 { get; set; }
        public int ContribuyenteId { get; set; } //Si RncCedula no es fk

        public Contribuyente Contribuyente { get; set; }
    }
}
