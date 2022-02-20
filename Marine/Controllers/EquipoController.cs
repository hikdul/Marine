using AutoMapper;
using Marine.Data;
using Marine.DTOs;
using Marine.Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marine.Controllers
{
    /// <summary>
    /// para manipular la data del equipo
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {

        #region ctor
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public EquipoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #endregion



        #region create
        /// <summary>
        /// para agregar un nuevo turno
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ActionResult> Post(EquipoDTO_in ins)
        {
            try
            {

                var entT = mapper.Map<Turnos>(ins.turno);

                context.Add(entT);

                await context.SaveChangesAsync();

                foreach (var item in ins.cargos)
                {
                    var ent = new Equipo()
                    {
                        CantCubierta = item.CantCubierta,
                        Cargoid = item.Cargoid,
                        CostoOperario = item.CostoOperario,
                        Turnoid = entT.id
                    };

                    context.Add(ent);
                }
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest("upss, Error inesperado. Intente Mas Tarde");
            }
        }



        #endregion




    }

}
