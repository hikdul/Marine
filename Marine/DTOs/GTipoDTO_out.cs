namespace Marine.DTOs
{
    /// <summary>
    /// tipos en general para mostrar sus datos
    /// </summary>
    public class GTipoDTO_out
    {

        #region propiedades
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// nombre del marisco
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// descripcion
        /// </summary>
        public string Desc { get; set; } 
        /// <summary>
        /// si esta o no activo en base de datos
        /// </summary>
        public bool act { get; set; }
        #endregion

    }

}
