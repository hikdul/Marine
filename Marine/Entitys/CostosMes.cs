using AutoMapper;
using Marine.Data;
using Marine.DTOs;
using Marine.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Marine.Entitys
{
    /// <summary>
    /// para llevar el costo por mes en cada año. 
    /// este calculo se ara por dia hasta completar mes
    /// </summary>
    public class CostosMes
    {
        #region props

       

        /// <summary>
        /// numero de operadores promedio por mes
        /// </summary>

        // === Calculo operadores
        // === === === === === ===


        public double NumOperadores{ get; set; }
        /// <summary>
        /// porcentaje de operadores cubiertos
        /// </summary>
        public double PorcentajeOperadoresCubiertos { get; set; }
        /// <summary>
        /// costo promedio de productos por dia
        /// </summary>
        public double CostoPromedioEquipoPorDia { get; set; }

        // === Calculo Producto
        // === === === === === ===

        /// <summary>
        /// Cantidad promedio de productos por dia
        /// </summary>
        public double KgProductoPromedioPorDia { get; set; }

        // === Identificadores
        // === === === === ===


        /// <summary>
        /// año de estudio
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Mes del estudio
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// equipo al que se le sacan los calculos
        /// </summary>
        public int Equipoid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Equipo Equipo { get; set; }
        /// <summary>
        /// Marisco
        /// </summary>
        public int Mariscoid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Marisco Marisco { get; set; }
        /// <summary>
        /// Calibre
        /// </summary>
        public int Calibreid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Calibre Calibre { get; set; }
        /// <summary>
        /// Tipo de produccion
        /// </summary>
        public int TipoProduccionid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public TipoProduccion TipoProduccion { get; set; }


        #endregion

        #region ctor
        /// <summary>
        /// empty
        /// </summary>
        public CostosMes()
        {
            
        }

        #endregion

        #region Construir Data
        /// <summary>
        /// es para que me genere los datos para todos los producton viables
        /// </summary>
        /// <param name="context"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task CompleteDataBase(ApplicationDbContext context, DateTime date)
        {

            try
            {
                var prod = await ObtenerProductos(context);
                var equipo = await context
                    .Turnos
                    .Where(x => x.act == true)
                    .ToListAsync();
                if(equipo != null && prod != null)
                foreach (var elements in prod)
                    foreach (var eq in equipo)
                    {
                        CostosMes ent = new();

                            ent.Month = date.Month;
                            ent.Year = date.Year;
                                
                            var este = await ObtenerEstudioActual(context, date, elements.Mariscoid, elements.Calibreid, elements.tipoProduccionid);
                            await ent.Operadores(context,eq.id, date, elements.Mariscoid, elements.Calibreid, elements.tipoProduccionid, este);
                            await ent.productoPorDia(context, date, elements.Mariscoid, elements.Calibreid, elements.tipoProduccionid, este);
                            context.Add(ent);
                    }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }

        }


        #endregion

        #region obtener listado de productos


        private async Task<List<ProductoCosto>> ObtenerProductos(ApplicationDbContext context)
        {
            List<ProductoCosto> list = new();
            try
            {
                var producto = await context
                    .Productos
                    .Where(x => x.act == true)
                    .ToListAsync();
                if(producto!= null && producto.Count > 0)
                foreach (var item in producto)
                        if(list.FindIndex(x => x.Calibreid == item.Calibreid && x.tipoProduccionid == item.TipoProduccionid && x.Mariscoid == item.Mariscoid) == 0)
                            list.Add(new()
                            {
                                Productoid = item.id,
                                Calibreid = item.Calibreid,
                                Mariscoid = item.Mariscoid,
                                tipoProduccionid= item.TipoProduccionid,
                            });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           return list;
        }


        #endregion

        #region costos con operadores

        /// <summary>
        /// Para obtener los calculos de los operadores
        /// </summary>
        /// <param name="context"></param>
        /// <param name="Equipoid"></param>
        /// <param name="date"></param>
        /// <param name="Marisco"></param>
        /// <param name="calibre"></param>
        /// <param name="tp"></param>
        /// <returns></returns>
        private async Task Operadores(ApplicationDbContext context,  int Equipoid, DateTime date, int Marisco, int calibre, int tp, CostosMes este = null)
        {

            try
            {
                this.Equipoid = Equipoid;

                var AuxEquipo = await context
                    .Equipos
                    .Include(x => x.Turno)
                    .Where(x => x.Turnoid == Equipoid)
                    .ToListAsync();

                EquipoDTO_out equipo;

                if (AuxEquipo.Count > 0)
                    equipo = new(AuxEquipo, AuxEquipo[0].Turno);
                else
                    return;
                int acumCubiertos = 0;
                double sumCosto = 0;
                int acumNecesarios = 0;

                foreach (var item in equipo.Cargos)
                {
                    acumCubiertos += item.CantCubierta;
                    acumNecesarios += item.CantOperadoresNecesario;
                    sumCosto += item.CostoOperario * item.CantCubierta;
                }


               


                var HoyPorcentajeOperadoresCubiertos = acumCubiertos * 100 / acumNecesarios;
                
                var HoyNumOperadores = acumCubiertos;
                
                var HoyCostoPromedioEquipoPorDia = sumCosto / DateGame.DaysInMont(date);


                if (acumCubiertos <= 0 || acumNecesarios <= 0 || sumCosto <= 0 && este != null)
                {
                    this.PorcentajeOperadoresCubiertos = este.PorcentajeOperadoresCubiertos;
                    this.NumOperadores = este.NumOperadores;
                    this.CostoPromedioEquipoPorDia = este.CostoPromedioEquipoPorDia;

                }
                else
                {


                    if (este == null)
                    {
                        this.PorcentajeOperadoresCubiertos = HoyPorcentajeOperadoresCubiertos;
                        this.NumOperadores = HoyNumOperadores;
                        this.CostoPromedioEquipoPorDia = HoyCostoPromedioEquipoPorDia;
                    }
                    else
                    {
                        if (HoyCostoPromedioEquipoPorDia > 0)
                            this.PorcentajeOperadoresCubiertos = (este.PorcentajeOperadoresCubiertos + HoyPorcentajeOperadoresCubiertos) / 2;
                        else
                            this.PorcentajeOperadoresCubiertos = este.PorcentajeOperadoresCubiertos;

                        if (HoyNumOperadores > 0)
                            this.NumOperadores = (este.NumOperadores + HoyNumOperadores) / 2;
                        else
                            this.NumOperadores = este.NumOperadores;

                        if (HoyCostoPromedioEquipoPorDia > 0)
                            this.CostoPromedioEquipoPorDia = (este.CostoPromedioEquipoPorDia + HoyCostoPromedioEquipoPorDia) / 2;
                        else
                            this.CostoPromedioEquipoPorDia = este.CostoPromedioEquipoPorDia;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }



        #endregion

        #region cantidad de producto por dia

        /// <summary>
        /// calcula la cantidad de productos promedio por dia de produccion
        /// </summary>
        /// <param name="context"></param>
        /// <param name="date"></param>
        /// <param name="Marisco"></param>
        /// <param name="calibre"></param>
        /// <param name="tp"></param>
        /// <returns></returns>
        private async Task productoPorDia(ApplicationDbContext context, DateTime date, int Marisco, int calibre, int tp, CostosMes este = null)
        {
            try
            {

                var list = await context.Produccion
                    .Include(x => x.ProductoProduccion).ThenInclude(x => x.Producto)
                    .Where(x =>
                x.Fecha.Year == date.Year
                && x.Fecha.Month == date.Month
                && x.Fecha.Day == date.Day
                ).ToListAsync();

                List<Produccion> validList = new();
                double flag = 0;
                foreach (var item in list)
                    foreach (var prod in item.ProductoProduccion)
                        if (prod.Producto.Mariscoid == Marisco && prod.Producto.TipoProduccionid == tp && prod.Producto.Calibreid == calibre)
                            flag += prod.CantidadProducida;


                if (este == null)
                    this.KgProductoPromedioPorDia = flag;
                else
                    this.KgProductoPromedioPorDia = (este.KgProductoPromedioPorDia + flag) / 2;

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }



        #endregion

        #region consultar actual
        /// <summary>
        /// para buscar el elemento de estudio actual en base a la fecha
        /// </summary>
        /// <param name="context"></param>
        /// <param name="date"></param>
        /// <param name="Marisco"></param>
        /// <param name="calibre"></param>
        /// <param name="tp"></param>
        /// <returns></returns>

        private static async Task<CostosMes> ObtenerEstudioActual(ApplicationDbContext context, DateTime date, int Marisco, int calibre, int tp )
        {

            try
            {
                var resp =  await context.CostosMes.Where(x => x.Month == date.Month
                  && x.Year == date.Year
                  && x.Mariscoid == Marisco
                  && x.Calibreid == calibre
                  && x.TipoProduccionid == tp
                  ).FirstOrDefaultAsync();

                return resp == null  ? null : resp;

            }catch(Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return null;
            }
        }


        #endregion

    }
}
