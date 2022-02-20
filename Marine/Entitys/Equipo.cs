namespace Marine.Entitys
{
    /// <summary>
    /// equipo de trabajo
    /// esto se generan por turno
    /// </summary>
    public class Equipo
    {
        /// <summary>
        /// turno al que pertenece el equipo
        /// </summary>
        public int Turnoid { get; set; }
        /// <summary>
        /// cargo que se le asigna al equipo
        /// </summary>
        public int Cargoid { get; set; }

        /// <summary>
        /// nav prop
        /// </summary>
        public Turnos Turno { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Cargos Cargo { get; set; }
        /// <summary>
        /// cantidad cubierta
        /// </summary>
        public int CantCubierta { get; set; }

    }
}
