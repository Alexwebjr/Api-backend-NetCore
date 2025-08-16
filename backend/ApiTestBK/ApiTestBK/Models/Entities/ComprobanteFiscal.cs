using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTestBK.Models.Entities
{
    public class ComprobanteFiscal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string RncCedula { get; set; } //fk contribuyente
        public string? NCF { get; set; }
        public decimal Monto { get; set; }
        public decimal Itbis18 { get; set; }

        //Propiedad de navegacion opcional en EF
        [ForeignKey("RncCedula")]
        public Contribuyente Contribuyente { get; set; }
    }
}
