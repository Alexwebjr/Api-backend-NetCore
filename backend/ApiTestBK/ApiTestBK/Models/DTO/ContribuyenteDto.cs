using ApiTestBK.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTestBK.Models.DTO
{
    public class ContribuyenteDto
    {
        public required string RncCedula { get; set; }
        public required string Nombre { get; set; }
        public string? Tipo { get; set; } //Puede ser una tabla adicional
        public string? Estatus { get; set; } //Puede ser una tabla adicional

        public List<ComprobanteFiscalDto> ComprobantesFiscales { get; set; } = new();
    }
}
