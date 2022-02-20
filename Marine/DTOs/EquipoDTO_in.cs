using Marine.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Marine.DTOs
{
    public class EquipoDTO_in
    {

        public GTipoDTO_in turno { get; set; }
        /// <summary>
        /// cargos y cantidades cubiertas
        /// </summary>
        [ModelBinder(BinderType = typeof(TypeBinder<List<__in>>))]
        public List<__in> cargos { get; set; }
    }


    public class __in
    {
        public int Cargoid { get; set; }

        public int CantCubierta { get; set; }
    }

}
