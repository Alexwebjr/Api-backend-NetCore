using ApiTestBK.Models;
using ApiTestBK.Models.DTO;
using ApiTestBK.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTestBK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyentesController : ControllerBase
    {
        //Inyección de dependencias + Log + DbContext
        private readonly ILogger<ContribuyentesController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public ContribuyentesController(
            ILogger<ContribuyentesController> logger,
            ApplicationDbContext dbContext
            )
        {
            _logger = logger;
            this._dbContext = dbContext;
        }


        // Temporal Data


        // GET: api/Contribuyentes
        [HttpGet]
        public async Task<ActionResult<List<ContribuyenteDto>>> GetAll()
        {
            _logger.LogInformation("Entrando al mmétodo GetAll Contribuyentes");

            var data = await _dbContext.Contribuyentes
           .AsNoTracking()
           .Select(c => new ContribuyenteDto
           {
               RncCedula = c.RncCedula,
               Nombre = c.Nombre,
               Tipo = c.Tipo,
               Estatus = c.Estatus,
               ComprobantesFiscales = c.ComprobantesFiscales
                   .Select(cf => new ComprobanteFiscalDto
                   {
                       RncCedula = cf.RncCedula,
                       NCF = cf.NCF,
                       Monto = cf.Monto,
                       Itbis18 = cf.Itbis18
                   })
                   .ToList()
           })
           .ToListAsync();
            //Podemos usar Lazy loading para que sea mas eficiente

            return Ok(data);
        }
       
        // GET: api/Contribuyentes/00112345678
        [HttpGet("{rncCedula}")]
        public async Task<ActionResult<ContribuyenteDto>> GetByRncCedula(string rncCedula)
        {
            _logger.LogInformation("Entrando al método Get Contribuyente by RncCedula {rncCedula}", rncCedula);

            var data = await _dbContext.Contribuyentes
            .AsNoTracking()
            .Where(c => c.RncCedula == rncCedula)
            .Select(c => new ContribuyenteDto
            {
                RncCedula = c.RncCedula,
                Nombre = c.Nombre,
                Tipo = c.Tipo,
                Estatus = c.Estatus,
                ComprobantesFiscales = c.ComprobantesFiscales
                    .Select(cf => new ComprobanteFiscalDto
                    {
                        RncCedula = cf.RncCedula,
                        NCF = cf.NCF,
                        Monto = cf.Monto,
                        Itbis18 = cf.Itbis18
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync();

            if (data == null) return NotFound();

            return Ok(data);
        }

        //// GET: api/Contribuyentes/2
        //[HttpGet("{id}")]
        //public ActionResult<Contribuyente> GetById(int id)
        //{
        //    var contribuyente = _dbContext.Contribuyentes.FirstOrDefault(c => c.Id == id);
        //    if (contribuyente == null)
        //        return NotFound();

        //    return Ok(contribuyente);
        //}

    }
}
