using System.ComponentModel.DataAnnotations;

namespace Marine.Entitys
{
    /// <summary>
    /// para almacenar la materia prima
    /// </summary>
    public class MateriaPrima
    {
        #region prop
        /// <summary>
        /// id
        /// </summary>
        [Key]        
        public int id { get; set; }
        /// <summary>
        /// marisco al que pertenece
        /// </summary>
        public int Mariscoid { get; set; }
        /// <summary>
        /// prop de nav
        /// </summary>
        public Marisco Marisco { get; set; }
        /// <summary>
        /// cantidad del marisco
        /// </summary>
        [Range(0, double.MaxValue)]

        public double Cantidad { get; set; } = 0;

        #endregion




    }
}
