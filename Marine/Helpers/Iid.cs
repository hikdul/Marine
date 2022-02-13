namespace Marine.Helpers
{
    /// <summary>
    /// para mantener aquellas clases que tienen este par de elementos1
    /// </summary>
    public interface Iid
    {
        /// <summary>
        /// identificador
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// si esta activo o no en base de datos
        /// </summary>
        public bool act { get; set; }
    }
}
