using Marine.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Marine.Entitys
{
    /// <summary>
    /// definen el modo en que se guardan los productos por paquetes
    /// </summary>
    public class Empaquetado : ITipo
    {
        #region propiedades
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// nombre del marisco
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// descripcion
        /// </summary>
        [StringLength(50)]
        public string Desc { get; set; } = "";
        /// <summary>
        /// si esta o no activo en base de datos
        /// </summary>
        public bool act { get; set; } = true;
        #endregion



    }
}
