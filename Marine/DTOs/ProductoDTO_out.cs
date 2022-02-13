using Marine.Entitys;
using System.ComponentModel.DataAnnotations;

namespace Marine.DTOs
{
    /// <summary>
    /// para obtener los datos de un producto
    /// </summary>
    public class ProductoDTO_out
    {
        #region props
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// si esta activo o no en base de datos
        /// </summary>
        public bool act { get; set; } = true;

        /// <summary>
        /// marisco
        /// </summary>
        public string Marisco { get; set; }

        /// <summary>
        /// tipo de produccion
        /// </summary>
        public string TipoProduccion { get; set; }

        /// <summary>
        /// calibre
        /// </summary>
        public string Calibre { get; set; }
        /// <summary>
        /// empaquetado
        /// </summary>
        public string Empaquetado { get; set; }
        #endregion



    }
}
