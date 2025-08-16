using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTestBK.Models.Entities
{
    public class Contribuyente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string RncCedula { get; set; } //Puede ser pk si solo existirá un contribuyente con el mismo rncCedula
        public required string Nombre { get; set; }
        public string? Tipo { get; set; } //en caso de que sea opcional
        public string? Estatus {get; set; }

        //Relacion
        public List<ComprobanteFiscal> ComprobantesFiscales { get; set; } = new List<ComprobanteFiscal>();
    }
}
