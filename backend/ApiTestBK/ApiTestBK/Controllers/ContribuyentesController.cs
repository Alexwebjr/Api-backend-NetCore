using ApiTestBK.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTestBK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyentesController : ControllerBase
    {
        //Inyección de dependencias + Log
        private readonly ILogger<ContribuyentesController> _logger;

        public ContribuyentesController(ILogger<ContribuyentesController> logger)
        {
            _logger = logger;
        }


        // Temporal Data
        private static readonly List<Contribuyente> Contribuyentes = new()
{
    new Contribuyente
    {
        Id = 1,
        RncCedula = "00112345678",
        Nombre = "JUAN PEREZ",
        Tipo = "PERSONA FISICA",
        Estatus = "activo",
        ComprobantesFiscales = new List<ComprobanteFiscal>
        {
            new ComprobanteFiscal { Id = 1, RncCedula = "00112345678", NCF = "E310000000001", Monto = 200.00m, Itbis18 = 36.00m },
            new ComprobanteFiscal { Id = 2, RncCedula = "00112345678", NCF = "E310000000002", Monto = 1500.00m, Itbis18 = 270.00m }
        }
    },
    new Contribuyente
    {
        Id = 2,
        RncCedula = "00187654321",
        Nombre = "MARIA LOPEZ",
        Tipo = "PERSONA FISICA",
        Estatus = "activo",
        ComprobantesFiscales = new List<ComprobanteFiscal>
        {
            new ComprobanteFiscal { Id = 3, RncCedula = "00187654321", NCF = "E310000000003", Monto = 500.00m, Itbis18 = 90.00m }
        }
    },
    new Contribuyente
    {
        Id = 3,
        RncCedula = "13145678901",
        Nombre = "EMPRESAS DOMINICANAS SRL",
        Tipo = "PERSONA JURIDICA",
        Estatus = "inactivo",
        ComprobantesFiscales = new List<ComprobanteFiscal>
        {
            new ComprobanteFiscal { Id = 4, RncCedula = "13145678901", NCF = "B010000000001", Monto = 10000.00m, Itbis18 = 1800.00m },
            new ComprobanteFiscal { Id = 5, RncCedula = "13145678901", NCF = "B010000000002", Monto = 7500.00m, Itbis18 = 1350.00m },
            new ComprobanteFiscal { Id = 6, RncCedula = "13145678901", NCF = "B010000000003", Monto = 2500.00m, Itbis18 = 450.00m }
        }
    },
    new Contribuyente
    {
        Id = 4,
        RncCedula = "40211222333",
        Nombre = "PEDRO GARCIA",
        Tipo = "PERSONA FISICA",
        Estatus = "suspendido",
        ComprobantesFiscales = new List<ComprobanteFiscal>() // vacío
    },
    new Contribuyente
    {
        Id = 5,
        RncCedula = "40199887766",
        Nombre = "SOLUCIONES TECNICAS EIRL",
        Tipo = "PERSONA JURIDICA",
        Estatus = "activo",
        ComprobantesFiscales = new List<ComprobanteFiscal>
        {
            new ComprobanteFiscal { Id = 7, RncCedula = "40199887766", NCF = "E310000000004", Monto = 1200.00m, Itbis18 = 216.00m },
            new ComprobanteFiscal { Id = 8, RncCedula = "40199887766", NCF = "E310000000005", Monto = 300.00m, Itbis18 = 54.00m }
        }
    }
};


        // GET: api/Contribuyentes
        [HttpGet]
        public ActionResult<IEnumerable<Contribuyente>> GetAll()
        {
            _logger.LogInformation("Entrando al mmétodo GetAll Contribuyentes");

            return Ok(Contribuyentes);
        }
       
        // GET: api/Contribuyentes/00112345678
        [HttpGet("{rncCedula}")]
        public ActionResult<Contribuyente> GetByRncCedula(string rncCedula)
        {
            _logger.LogInformation("Entrando al mmétodo Get Contribuyente by RncCedula");

            var contribuyente = Contribuyentes.FirstOrDefault(c => c.RncCedula == rncCedula);
            if (contribuyente == null)
                return NotFound();

            return Ok(contribuyente);
        }

        //// GET: api/Contribuyentes/2
        //[HttpGet("{id}")]
        //public ActionResult<Contribuyente> GetById(int id)
        //{
        //    var contribuyente = Contribuyentes.FirstOrDefault(c => c.Id == id);
        //    if (contribuyente == null)
        //        return NotFound();

        //    return Ok(contribuyente);
        //}

    }
}
