using ApiTestBK.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTestBK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyentesController : ControllerBase
    {
        //Temporal Data
        private static readonly List<Contribuyente> Contribuyentes = new()
        {
            new Contribuyente { Id = 1, RncCedula = "00112345678", Nombre = "JUAN PEREZ", Tipo = "PERSONA FISICA", Estatus = "activo" },
            new Contribuyente { Id = 2, RncCedula = "00187654321", Nombre = "MARIA LOPEZ", Tipo = "PERSONA FISICA", Estatus = "activo" },
            new Contribuyente { Id = 3, RncCedula = "13145678901", Nombre = "EMPRESAS DOMINICANAS SRL", Tipo = "PERSONA JURIDICA", Estatus = "inactivo" },
            new Contribuyente { Id = 4, RncCedula = "40211222333", Nombre = "PEDRO GARCIA", Tipo = "PERSONA FISICA", Estatus = "suspendido" },
            new Contribuyente { Id = 5, RncCedula = "40199887766", Nombre = "SOLUCIONES TECNICAS EIRL", Tipo = "PERSONA JURIDICA", Estatus = "activo" }
        };

        // GET: api/Contribuyentes
        [HttpGet]
        public ActionResult<IEnumerable<Contribuyente>> GetAll()
        {
            return Ok(Contribuyentes);
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

        // GET: api/Contribuyentes/00112345678
        [HttpGet("{rncCedula}")]
        public ActionResult<Contribuyente> GetByRncCedula(string rncCedula)
        {
            var contribuyente = Contribuyentes.FirstOrDefault(c => c.RncCedula == rncCedula);
            if (contribuyente == null)
                return NotFound();

            return Ok(contribuyente);
        }
    }
    }
