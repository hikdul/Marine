using System.ComponentModel.DataAnnotations;

namespace Marine.Entitys
{
    /// <summary>
    /// para llevar el historial de lo que ingresa al almacen de materia prima
    /// </summary>
    public class HistorialMateriaPrima
    {

        /// <summary>
        /// id
        /// </summary>

        [Key]
        public int id { get; set; }
        /// <summary>
        /// marisco que ingresa
        /// </summary>
        public int Mariscoid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Marisco Marisco { get; set; }
        /// <summary>
        /// Cantidad que ha ingresado
        /// </summary>
        [Range(0,double.MaxValue)]
        public double Cantidad { get; set; }
        /// <summary>
        /// fecha en la que ingreso
        /// </summary>
        public DateTime Fecha { get; set; } = DateTime.Now;
        /// <summary>
        /// usuario que realizo el ingreso
        /// </summary>
        public int Usuarioid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Usuarios Usuario { get; set; }
        /// <summary>
        /// afirma si es un ingreso o egreso
        /// </summary>
        public bool Ingreso { get; set; }

    }
}
