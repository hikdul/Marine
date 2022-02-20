using Marine.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Marine.Entitys
{
    /// <summary>
    /// Para mantener el nombre de los turnos necesarios
    /// </summary>
    public class Turnos : Iid, ITipo
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// active
        /// </summary>
        public bool act { get; set; } = true;
        /// <summary>
        /// nombre del turno
        /// </summary>
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        /// <summary>
        /// descripcion del turno
        /// </summary>
        [StringLength(100)]
        public string Desc { get; set; } = String.Empty;
    }
}
