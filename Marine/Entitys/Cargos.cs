using Marine.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Marine.Entitys
{
    /// <summary>
    /// Cargos necesarios para que la planta funcione bien
    /// </summary>
    public class Cargos: Iid, ITipo
    {
        
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// nombre del cargo
        /// </summary>
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        /// <summary>
        /// descripcion del cargo
        /// </summary>
        [StringLength(50)]
        public string Desc { get; set; } = string.Empty;
        /// <summary>
        /// si el cargo esta activo o no
        /// </summary>
        public bool act { get; set; } = true;
        /// <summary>
        /// Cantidad Operadores Necesaria
        /// </summary>
        [Range(0, int.MaxValue)]
        public int CantOperadoresNecesario { get; set; } = 1;
    }
}
