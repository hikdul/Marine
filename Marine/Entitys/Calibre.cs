using Marine.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Marine.Entitys
{
    /// <summary>
    /// para almacenar los datos de un calibre
    /// esto son en cierto modo los tamaños de los mariscos
    /// </summary>
    public class Calibre : ITipo
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
