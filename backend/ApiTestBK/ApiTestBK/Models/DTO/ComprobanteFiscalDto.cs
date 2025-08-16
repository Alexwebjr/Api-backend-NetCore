namespace ApiTestBK.Models.DTO
{
    public class ComprobanteFiscalDto
    {
        public required string RncCedula { get; set; }
        public string? NCF { get; set; }
        public decimal Monto { get; set; }
        public decimal Itbis18 { get; set; }
    }
}
