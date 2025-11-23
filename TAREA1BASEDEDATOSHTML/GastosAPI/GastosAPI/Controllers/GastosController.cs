using Microsoft.AspNetCore.Mvc;
using GastosAPI.Models;

namespace GastosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GastosController : ControllerBase
    {
        // Lista en memoria para almacenar los gastos (temporal)
        private static List<Gasto> gastos = new List<Gasto>
        {
            new Gasto 
            { 
                Id = 1, 
                Descripcion = "Lapices", 
                TipoGasto = "Artículos de oficina", 
                Monto = 10.00m, 
                Fecha = new DateTime(2025, 11, 7) 
            }
        };
        
        private static int nextId = 2;

        // GET: api/gastos
        [HttpGet]
        public ActionResult<IEnumerable<Gasto>> GetGastos()
        {
            return Ok(gastos);
        }

        // GET: api/gastos/5
        [HttpGet("{id}")]
        public ActionResult<Gasto> GetGasto(int id)
        {
            var gasto = gastos.FirstOrDefault(g => g.Id == id);
            if (gasto == null)
            {
                return NotFound();
            }
            return Ok(gasto);
        }

        // POST: api/gastos
        [HttpPost]
        public ActionResult<Gasto> PostGasto(Gasto gasto)
        {
            gasto.Id = nextId++;
            gastos.Add(gasto);
            return CreatedAtAction(nameof(GetGasto), new { id = gasto.Id }, gasto);
        }

        // PUT: api/gastos/5
        [HttpPut("{id}")]
        public IActionResult PutGasto(int id, Gasto gasto)
        {
            var gastoExistente = gastos.FirstOrDefault(g => g.Id == id);
            if (gastoExistente == null)
            {
                return NotFound();
            }

            gastoExistente.Descripcion = gasto.Descripcion;
            gastoExistente.TipoGasto = gasto.TipoGasto;
            gastoExistente.Monto = gasto.Monto;
            gastoExistente.Fecha = gasto.Fecha;

            return NoContent();
        }

        // DELETE: api/gastos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteGasto(int id)
        {
            var gasto = gastos.FirstOrDefault(g => g.Id == id);
            if (gasto == null)
            {
                return NotFound();
            }

            gastos.Remove(gasto);
            return NoContent();
        }
    }
}