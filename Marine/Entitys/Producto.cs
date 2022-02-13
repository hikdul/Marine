using Marine.Data;
using Marine.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Marine.Entitys
{
    /// <summary>
    /// es donde se definen los productos finales
    /// </summary>
    public class Producto : Iid
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

        // ### de aqui definimos las propiedades del producto
        // ### ===========================

        /// <summary>
        /// Marisco al que pertenece el producto
        /// </summary>
        public int Mariscoid { get; set; }
        /// <summary>
        /// prop de nav
        /// </summary>
        public Marisco Marisco { get; set; }

        /// <summary>
        /// tipo de produccion al que se refiere
        /// </summary>
        public int TipoProduccionid { get; set; }
        /// <summary>
        /// prop de nav
        /// </summary>
        public TipoProduccion TipoProduccion { get; set; }

        /// <summary>
        /// calibre del Tipo de produccion
        /// </summary>
        public int Calibreid { get; set; }
        /// <summary>
        /// prop de nav
        /// </summary>
        public Calibre Calibre { get; set; }
        /// <summary>
        /// Empaquetado del producto
        /// </summary>
        public int Empaquetadoid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Empaquetado Empaquetado { get; set; }
        #endregion


     

    }
}
