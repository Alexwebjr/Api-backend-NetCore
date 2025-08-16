using ApiTestBK.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTestBK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobantesFiscalesController : ControllerBase
    {
        //Temporal Data
        private static readonly List<ComprobanteFiscal> Comprobantes = new()
        {
            new ComprobanteFiscal
            {
                Id = 1,
                RncCedula = "00112345678",
                NCF = "E310000000001",
                Monto = 200.00m,
                Itbis18 = 36.00m
            },
            new ComprobanteFiscal
            {
                Id = 2,
                RncCedula = "00112345678",
                NCF = "E310000000002",
                Monto = 1500.00m,
                Itbis18 = 270.00m
            },
            new ComprobanteFiscal
            {
                Id = 3,
                RncCedula = "00187654321",
                NCF = "E310000000003",
                Monto = 500.00m,
                Itbis18 = 90.00m
            },
            new ComprobanteFiscal
            {
                Id = 4,
                RncCedula = "131456789",
                NCF = "B010000000001",
                Monto = 10000.00m,
                Itbis18 = 1800.00m
            },
            new ComprobanteFiscal
            {
                Id = 5,
                RncCedula = "131456789",
                NCF = "B010000000002",
                Monto = 7500.00m,
                Itbis18 = 1350.00m
            },
            new ComprobanteFiscal
            {
                Id = 6,
                RncCedula = "131456789",
                NCF = "B010000000003",
                Monto = 2500.00m,
                Itbis18 = 450.00m
            },
            new ComprobanteFiscal
            {
                Id = 7,
                RncCedula = "40199887766",
                NCF = "E310000000004",
                Monto = 1200.00m,
                Itbis18 = 216.00m
            },
            new ComprobanteFiscal
            {
                Id = 8,
                RncCedula = "40199887766",
                NCF = "E310000000005",
                Monto = 300.00m,
                Itbis18 = 54.00m
            }
        };

        // GET: api/ComprobantesFiscales
        [HttpGet]
        public ActionResult<IEnumerable<ComprobanteFiscal>> GetAll()
        {
            return Ok(Comprobantes);
        }

        // GET: api/ComprobantesFiscales/00112345678
        [HttpGet("{id}")]
        public ActionResult<ComprobanteFiscal> GetById(int id)
        {
            var comprobantes = Comprobantes.FirstOrDefault(c => c.Id == id);
            if (comprobantes == null)
                return NotFound();

            return Ok(comprobantes);
        }

        // GET: api/ComprobantesFiscales/00112345678
        [HttpGet("listado/{rncCedula}")]
        public ActionResult<IEnumerable<ComprobanteFiscal>> GetByRncCedula(string rncCedula)
        {
            var comprobantes = Comprobantes.Where(c => c.RncCedula == rncCedula);
            if (comprobantes == null)
                return NotFound();

            return Ok(comprobantes);
        }
    }
}
