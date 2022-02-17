using Marine.Entitys;

namespace Marine.DTOs
{
    /// <summary>
    /// copia del original
    /// </summary>
    public class AlmacenDTO
    {

        #region props

        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Cantidad en el almacen
        /// </summary>

        public double Cantidad { get; set; } = 0;

        /// <summary>
        /// Producto
        /// </summary>
        public int Productoid { get; set; }

        /// <summary>
        /// prop nav
        /// </summary>
        public Producto Producto { get; set; }

        #endregion

    }
}
