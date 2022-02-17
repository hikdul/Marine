using AutoMapper;
using Marine.DTOs;
using Marine.Entitys;

namespace Marine.Helpers
{
    /// <summary>
    /// Para almacenar todos mis mapeos
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// desde aca ocurren los mapeos
        /// </summary>
        public AutoMapperProfile()
        {
            MariscosMap();
            CalibresMap();
            TipoProduccionsMap();
            EmpaquetadosMap();
            ProductoMap();
            MateriaPrimaMap();
            AlmacenMap();
        }


        #region Marisco


        private void MariscosMap()
        {
            CreateMap<GTipoDTO_in, Marisco>()
                .ForMember(x => x.act, opt => opt.MapFrom(y => true));

            CreateMap<GTipoDTO_out, Marisco>()
                .ReverseMap();

        }



        #endregion

        #region Calibre


        private void CalibresMap()
        {
            CreateMap<GTipoDTO_in, Calibre>()
                .ForMember(x => x.act, opt => opt.MapFrom(y => true));

            CreateMap<GTipoDTO_out, Calibre>()
                .ReverseMap();

        }



        #endregion

        #region TipoProduccion


        private void TipoProduccionsMap()
        {
            CreateMap<GTipoDTO_in, TipoProduccion>()
                .ForMember(x => x.act, opt => opt.MapFrom(y => true));

            CreateMap<GTipoDTO_out, TipoProduccion>()
                .ReverseMap();

        }



        #endregion

        #region Empaquetado


        private void EmpaquetadosMap()
        {
            CreateMap<GTipoDTO_in, Empaquetado>()
                .ForMember(x => x.act, opt => opt.MapFrom(y => true));

            CreateMap<GTipoDTO_out, Empaquetado>()
                .ReverseMap();

        }



        #endregion

        #region producto

        private void ProductoMap()
        {
            CreateMap<ProductoDTO_in, Producto>()
                .ForMember(x => x.Calibre, opt => opt.Ignore())
                .ForMember(x => x.TipoProduccion, opt => opt.Ignore())
                .ForMember(x => x.Marisco, opt => opt.Ignore())
                .ForMember(x => x.Empaquetado, opt => opt.Ignore())
                .ForMember(x => x.act, opt => opt.MapFrom(x => true));

            CreateMap<Producto, ProductoDTO_Details>()
                .ReverseMap();

            CreateMap<Producto, ProductoDTO_out>()
                .ForMember(x => x.Calibre, opt => opt.MapFrom(x => x.Calibre.Name))
                .ForMember(x => x.TipoProduccion, opt => opt.MapFrom(x => x.TipoProduccion.Name))
                .ForMember(x => x.Marisco, opt => opt.MapFrom(x => x.Marisco.Name))
                .ForMember(x => x.Empaquetado, opt => opt.MapFrom(x => x.Empaquetado.Name));

            

        }

        #endregion

        #region MateriaPrima

        private void MateriaPrimaMap()
        {
            CreateMap<MateriaPrima, MateriaPrimaDTO>().ReverseMap();

            CreateMap<MateriaPrimaDTO_in, MateriaPrima>()
                .ForMember(x => x.Marisco, opt => opt.Ignore());

            CreateMap<MateriaPrima, MateriaPrimaDTO_out>()
                .ForMember(x => x.Marisco, opt => opt.MapFrom(MateriaPrimaOnlyText));

        }

        private string MateriaPrimaOnlyText(MateriaPrima ent, MateriaPrimaDTO_out dto)
        {
            return ent.Marisco.Name;
        }

        #endregion

        #region Almacen

        private void AlmacenMap()
        {

            CreateMap<Almacen, AlmacenDTO>().ReverseMap();
            CreateMap<Almacen, AlmacenDTO_out>()
                .ForMember(x => x.Marisco, opt => opt.MapFrom(MariscoOutAlmacen))
                .ForMember(x => x.Calibre, opt => opt.MapFrom(CalibreOutAlmacen))
                .ForMember(x => x.TipoProduccion, opt => opt.MapFrom(TipoProdOutAlmacen))
                .ForMember(x => x.Empaquetado, opt => opt.MapFrom(EmpaquetadoOutAlmacen));



        }

        private string CalibreOutAlmacen(Almacen ent, AlmacenDTO_out dto)
        {
            return ent.Producto.Calibre.Name;
        }

        private string MariscoOutAlmacen(Almacen ent, AlmacenDTO_out dto)
        {
            return ent.Producto.Marisco.Name;
        }

        private string TipoProdOutAlmacen(Almacen ent, AlmacenDTO_out dto)
        {
            return ent.Producto.TipoProduccion.Name;
        }

        private string EmpaquetadoOutAlmacen(Almacen ent, AlmacenDTO_out dto)
        {
            return ent.Producto.Empaquetado.Name;
        }


        #endregion

    }
}
