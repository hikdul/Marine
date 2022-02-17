using AutoMapper;
using Marine.Data;
using Marine.Entitys;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Marine.DTOs
{
    /// <summary>
    /// Almacen dto in
    /// </summary>
    public class AlmacenDTO_in
    {
        #region props
        /// <summary>
        /// Cantidad de kg
        /// </summary>
        [Range(0,double.MaxValue)]
        public double Cantidad { get; set; } = 0;
        /// <summary>
        /// Marisco
        /// </summary>
        [Required]
        public int Marisco { get; set; }
        /// <summary>
        /// Tipo de produccion
        /// </summary>
        [Required]
        public int TipoProduccion { get; set; }
        /// <summary>
        /// Calibre
        /// </summary>
        [Required]
        public int Calibre { get; set; }
        /// <summary>
        /// Empaquetado
        /// </summary>
        [Required]
        public int Empaquetado { get; set; }
        #endregion


        #region add
        /// <summary>
        /// para agregar valores
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public async Task<AlmacenDTO_out> Add(ApplicationDbContext context, IMapper mapper)
        {

            try
            {

                var ent =await context.Almacen
                    .Include(a => a.Producto).ThenInclude(x => x.Marisco)
                    .Include(a => a.Producto).ThenInclude(x => x.TipoProduccion)
                    .Include(a => a.Producto).ThenInclude(x => x.Calibre)
                    .Include(a => a.Producto).ThenInclude(x => x.Empaquetado)
                    .Where(x =>
                x.Producto.Mariscoid == this.Marisco
                && x.Producto.Calibreid == this.Calibre
                && x.Producto.TipoProduccionid == this.TipoProduccion
                && x.Producto.Empaquetadoid == this.Empaquetado
                ).FirstOrDefaultAsync();

                if(ent != null && ent.id < 1)
                {
                    ent.Cantidad += this.Cantidad;
                    await context.SaveChangesAsync();
                    return mapper.Map<AlmacenDTO_out>(ent);
                }

                ent = mapper.Map<Almacen>(this);
                context.Add(ent);

                ent = await context.Almacen
                    .Include(a => a.Producto).ThenInclude(x => x.Marisco)
                    .Include(a => a.Producto).ThenInclude(x => x.TipoProduccion)
                    .Include(a => a.Producto).ThenInclude(x => x.Calibre)
                    .Include(a => a.Producto).ThenInclude(x => x.Empaquetado)
                    .Where(x => x.id == ent.id)
                    .FirstOrDefaultAsync();

                return mapper.Map<AlmacenDTO_out>(ent);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new();
            }

        }



        #endregion



        #region substract
        /// <summary>
        /// resta
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public async Task<AlmacenDTO_out> Substract(ApplicationDbContext context, IMapper mapper)
        {

            try
            {

                var ent = await context.Almacen
                    .Include(a => a.Producto).ThenInclude(x => x.Marisco)
                    .Include(a => a.Producto).ThenInclude(x => x.TipoProduccion)
                    .Include(a => a.Producto).ThenInclude(x => x.Calibre)
                    .Include(a => a.Producto).ThenInclude(x => x.Empaquetado)
                    .Where(x =>
                x.Producto.Mariscoid == this.Marisco
                && x.Producto.Calibreid == this.Calibre
                && x.Producto.TipoProduccionid == this.TipoProduccion
                && x.Producto.Empaquetadoid == this.Empaquetado
                ).FirstOrDefaultAsync();

                if (ent != null && ent.id < 1)
                {
                    ent.Cantidad -= this.Cantidad;
                    await context.SaveChangesAsync();
                    return mapper.Map<AlmacenDTO_out>(ent);
                }

                ent = mapper.Map<Almacen>(this);
                ent.Cantidad = 0;
                context.Add(ent);

                ent = await context.Almacen
                    .Include(a => a.Producto).ThenInclude(x => x.Marisco)
                    .Include(a => a.Producto).ThenInclude(x => x.TipoProduccion)
                    .Include(a => a.Producto).ThenInclude(x => x.Calibre)
                    .Include(a => a.Producto).ThenInclude(x => x.Empaquetado)
                    .Where(x => x.id == ent.id)
                    .FirstOrDefaultAsync();

                return mapper.Map<AlmacenDTO_out>(ent);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new();
            }

        }

        #endregion

    }
}
