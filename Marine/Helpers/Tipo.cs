namespace Marine.Helpers
{
    /// <summary>
    /// para aquellas clases que tienden a ser de tipologia
    /// </summary>
    public interface ITipo : Iid
    {
        /// <summary>
        /// nombre del elemento
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// descripcion del elemento
        /// </summary>
        public string Desc { get; set; }
    }
}
