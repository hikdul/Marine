using System.ComponentModel.DataAnnotations;

namespace Marine.Entitys
{
    /// <summary>
    /// pivote de mariscos usados en produccion
    /// </summary>
    public class PMariscoProduccion
    {
        /// <summary>
        /// marisco utilizado
        /// </summary>
        public int Mariscoid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Marisco Marisco { get; set; }

        /// <summary>
        /// produccion a la que pertenece
        /// </summary>
        public int Produccionid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Produccion Produccion { get; set; }
        /// <summary>
        /// cantidad utilizada
        /// </summary>
        [Range(0,double.MaxValue)]
        public double CantidadUtilizada { get; set; }

    }
}
