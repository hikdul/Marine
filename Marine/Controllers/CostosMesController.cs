using AutoMapper;
using Marine.Data;
using Marine.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marine.Controllers
{

    /// <summary>
    /// para observar los costos y su historial
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CostosMesController: BaseController
    {

        #region ctor
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public CostosMesController(ApplicationDbContext context, IMapper mapper): base(context,mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion



        #region historial
        /// <summary>
        /// Historial
        /// </summary>
        /// <returns></returns>
        [HttpPost("Periodo")]
        public async Task<ActionResult> Historial(Periodo periodo)
        {
            try
            {
                var ents = await context
                    .CostosMes
                    .Include( x => x.Marisco)
                    .Include( x => x.Calibre)
                    .Include( x => x.Equipo).ThenInclude(x => x.Turno)
                    .Include( x => x.TipoProduccion)
                    .Where(x => x.Year > periodo.Inicio.Year -1 
                    && x.Year < periodo.Fin.Year +1)
                    .ToListAsync();
                return Ok(mapper.Map<List<CostosMesDTO_out>>(ents));
            }
            catch (Exception o)
            {
                Console.Error.WriteLine(o.Message);
                return BadRequest("Algo salio mal, intente mas tarde");
            }
        }



        #endregion


        #region Calculo de posible fechas de entrega
        /// <summary>
        /// end point para calcular la fecha estimada de entrega por producto
        /// </summary>
        /// <returns></returns>

        [HttpPost("FechaPorProducto/{diasHabiles:int}")]
        public async Task<ActionResult> FechaPorProducto(int diasHabiles,CalcularFechaDTO_in finder)
        {
            try
            {
                CalcularFechaDTO_out ret;

                var hoy = DateTime.Now;

                var costos = await context.CostosMes.Where(e =>
               e.Equipoid == finder.Equipoid
               && e.Mariscoid == finder.Mariscoid
               && e.Calibreid == finder.Calibreid
               && e.TipoProduccionid == finder.TipoProduccionid
               && e.Month == hoy.Month
               && e.Year > hoy.Year - 5
               ).ToListAsync();

                if (costos == null || costos.Count == 0)
                {

                    int dias = (int)Math.Round( finder.CantKg / 20000);

                    dias = dias > 0 ? dias : 1;
                    dias = dias < 7 ? 7 : dias;
                    ret = new(dias, dias + (int)(dias/7), hoy.AddDays(dias + (int)(dias / 7)));

                    return Ok(ret);
                }

                int cont = 0;
                double kgDias = 0;

                foreach (var item in costos)
                {
                    cont++;
                    kgDias += item.KgProductoPromedioPorDia;
                }

                var total = (int)Math.Round(kgDias / cont);
                if (total < 0)
                    total = -total;
                //necesito saber los dias habiles para calcular cuntas semanas son
                int totalSr = total;
                int RestDays = 0;
                if(diasHabiles > 0 && diasHabiles < 7)
                    RestDays = 7 - diasHabiles;
                double semanas = total / 7;
                RestDays = RestDays * (int)semanas;

                total += RestDays;
                ret = new(totalSr, total, DateTime.Now.AddDays(total + 1));
                return Ok(ret);


            }
            catch (Exception)
            {
                return BadRequest("Upps, Algo salio mal.");
            }


        }



        #endregion




    }
}
