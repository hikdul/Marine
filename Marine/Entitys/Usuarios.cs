using Marine.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Marine.Entitys
{
    /// <summary>
    /// datos de los usuarios del sistema
    /// </summary>
    public class Usuarios
    {
        #region props
        /// <summary>
        /// id 
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// nombre del usuario
        /// </summary>
        [StringLength(50)]
        [Required(ErrorMessage ="El Nombre Es Necesario")]
        public string Nombre { get; set; }
        /// <summary>
        /// rut
        /// </summary>
        [StringLength(12)]
        public string rut { get; set; } = "";
        /// <summary>
        /// Email de ingreso al sistema
        /// </summary>
        [EmailAddress(ErrorMessage ="No Es Una Direccion De Correo Valida")]
        [Required(ErrorMessage ="El Correo Electronico es necesario")]
        public string Email { get; set; }
        /// <summary>
        /// telefono
        /// </summary>

        public string Telefono { get; set; } = "";
        /// <summary>
        /// identity user
        /// </summary>
        public IdentityUser User { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public string Userid { get; set; }
        /// <summary>
        /// para almacenar los roles
        /// => AdmoSistema ==> Administrador del sistema
        /// => Gerenteplanta ==> Genente de planta
        /// => Superv ==> Supervisor de Planta
        /// => Cliente ==> Cliente`
        /// </summary>
        public string Rol { get; set; }

        #endregion

        #region ctor
        /// <summary>
        /// empty
        /// </summary>
        public Usuarios()
        {

        }

        #endregion

        #region validar

        /// <summary>
        /// verifica si el usuario existe
        /// </summary>
        /// <param name="contex"></param>
        /// <param name="userManager"></param>
        /// <returns></returns>

        public async Task<bool> Exits(ApplicationDbContext contex, UserManager<IdentityUser> userManager)
        {
            var actual = await contex.AspNetUsuario.Where(x => x.Email == this.Email).FirstOrDefaultAsync();
            if (actual != null && actual.id > 0)
                return true;
             var identity = await userManager.FindByEmailAsync(this.Email);
             if (identity != null || identity.Email == this.Email)
                 return true;
            return false;
        }



        #endregion

        #region Rol

        /// <summary>
        /// para generar el rol de ingreso en base al generado en Identity
        /// 3 => AdmoSistema ==> Administrador del sistema
        /// 2 => Gerenteplanta ==> Genente de planta
        /// 1 => Superv ==> Supervisor de Planta
        /// 0 => Cliente ==> Cliente`
        /// </summary>
        /// <param name="User"></param>
        public void MyRol(System.Security.Claims.ClaimsPrincipal User)
        {
            if(User.IsInRole("AdmoSistema"))
                this.Rol ="Administrador Del Sistema";
            if(User.IsInRole("Gerenteplanta"))
                 this.Rol ="Gerente De Planta";
            if(User.IsInRole("Superv"))
                 this.Rol ="Supervisor De Planta";
            if (User.IsInRole("Cliente"))
                 this.Rol = "Cliente";

        }
        /// <summary>
        /// Para generarlo en base a un nivel
        /// </summary>
        /// <param name="lvl"></param>
        public void MyRol(int lvl)
        {
            if (lvl == 3)
                this.Rol = "Administrador Del Sistema";
            if (lvl == 2)
                this.Rol = "Gerente De Planta";
            if (lvl == 1)
                this.Rol = "Supervisor De Planta";
            if (lvl == 0)
                this.Rol = "Cliente";

        }

        /// <summary>
        /// para obtener el select de roles
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        public static List<SelectListItem> RolView(int rol = -1)
        {
            List<SelectListItem> roles = new();

            if (rol < 0)
                roles.Add(new SelectListItem("== SELECCIONE UN ROLE ==","",true));

            roles.Add(new("Administrador Del Sistema","3", rol == 3));
            roles.Add(new("Gerente De Planta", "2", rol == 2));
            roles.Add(new("Supervisor De Planta", "1", rol == 1));
            roles.Add(new("Cliente", "0", rol == 0));

            return roles;

        }

        /// <summary>
        /// retorna el valor del rol en identity deacuerdo al nivel
        /// </summary>
        /// <param name="lvl"></param>
        /// <returns></returns>
        public string MyRolIdentity(int lvl)
        {
            
            if (lvl == 3)
                return "AdmoSistema";
            if (lvl == 2)
                return "Gerenteplanta";
            if (lvl == 1)
                return "Superv";
            if (lvl == 0)
                return "Cliente";
            return "Cliente";
        }

        #endregion

        #region obtener usuarios

        /// <summary>
        /// para obtener los datos de un usuaro por su Email
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<Usuarios> GetByEmail(string Email, ApplicationDbContext context)
        {
            Usuarios ret = new();
            try
            {
                ret = await context.AspNetUsuario.Where(x => x.Email == Email).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return ret;
        }
      

        #endregion


    }
}
