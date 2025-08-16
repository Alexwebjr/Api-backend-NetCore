namespace ApiTestBK.Controllers
{
    internal class ComprobanteDto
    {
        private int id;
        private string rncCedula;
        private string? nCF;
        private decimal monto;
        private decimal itbis18;

        public ComprobanteDto(int id, string rncCedula, string? nCF, decimal monto, decimal itbis18)
        {
            this.id = id;
            this.rncCedula = rncCedula;
            this.nCF = nCF;
            this.monto = monto;
            this.itbis18 = itbis18;
        }
    }
}