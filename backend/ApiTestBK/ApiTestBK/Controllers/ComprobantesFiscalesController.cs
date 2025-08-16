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
    public class ComprobantesFiscalesController : ControllerBase
    {
        //Inyección de dependencias + Log
        private readonly ILogger<ComprobantesFiscalesController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public ComprobantesFiscalesController(
            ILogger<ComprobantesFiscalesController> logger,
            ApplicationDbContext dbContext
            )
        {
            _logger = logger;
            this._dbContext = dbContext;
        }

        // GET: api/ComprobantesFiscales
        [HttpGet]
        public async Task<ActionResult<ComprobanteFiscalDto>> GetAll()
        {
            _logger.LogInformation("Entrando al método GetAll Comprobantes");

            var data = await _dbContext.ComprobantesFiscales
               .AsNoTracking()
               .Select(c => new ComprobanteFiscalDto
               {
                   RncCedula = c.RncCedula,
                   NCF = c.NCF,
                   Monto = c.Monto,
                   Itbis18 = c.Itbis18
               })
               .ToListAsync();

            if (data == null) return NotFound();

            return Ok(data);
        }

        // GET: api/ComprobantesFiscales/00112345678
        [HttpGet("{id}")]
        public ActionResult<ComprobanteFiscal> GetById(int id)
        {
            _logger.LogInformation("Entrando al mmétodo GetById Comprobantes");

            var comprobantes = _dbContext.ComprobantesFiscales.FirstOrDefault(c => c.Id == id);
            if (comprobantes == null)
                return NotFound();

            return Ok(comprobantes);
        }

        // GET: api/ComprobantesFiscales/00112345678
        [HttpGet("listado/{rncCedula}")]
        public async Task<ActionResult<List<ComprobanteFiscalDto>>> GetByRncCedula(string rncCedula)
        {
            _logger.LogInformation("Entrando al mmétodo GetByRncCedula Comprobantes");

            var data = await _dbContext.ComprobantesFiscales
               .AsNoTracking()
               .Where(c => c.RncCedula == rncCedula)
               .Select(c => new ComprobanteFiscalDto
               {
                   RncCedula = c.RncCedula,
                   NCF = c.NCF,
                   Monto = c.Monto,
                   Itbis18 = c.Itbis18
               })
               .ToListAsync();


            return Ok(data);
        }
    }
}
