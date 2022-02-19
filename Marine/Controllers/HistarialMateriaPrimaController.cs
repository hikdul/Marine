using Marine.Data;
using Marine.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marine.Controllers
{
    /// <summary>
    /// para ver el historial de matera prima
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HistarialMateriaPrimaController : ControllerBase
    {

        #region ctor

        private readonly ApplicationDbContext context;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        public HistarialMateriaPrimaController(ApplicationDbContext context)
        {
            this.context = context;
        }



        #endregion




        #region ver historial

        /// <summary>
        /// para ver el esturial en un periodo predeterminado
        /// </summary>
        /// <param name="periodo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Historial(Periodo periodo)
        {
            try
            {

                var hs = await context
                    .HistorialMateriaPrima
                    .Where(x => x.Fecha >= periodo.Inicio && x.Fecha <= periodo.Fin)
                    .ToListAsync();
                return Ok(hs);

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return BadRequest("Upss, Algo Salio mal intente mas tarde");
            }
        }
        #endregion

    }
}
