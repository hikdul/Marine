namespace Marine.DTOs
{
    /// <summary>
    /// datos que se muestran sobre la materia prima
    /// </summary>
    public class MateriaPrimaDTO_out
    {
        #region props
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Marisco
        /// </summary>
        public string Marisco { get; set; }
        /// <summary>
        /// Cantidad
        /// </summary>
        public double Cantidad { get; set; }
        #endregion
    }
}
