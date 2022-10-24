using System.ComponentModel.DataAnnotations;
namespace web_api_db.Models{
    public class Empleados{
        [Key]
        public int id_empleados{get;set;}
        public string nombre {get;set;}
        public string apellido {get;set;}
        public string Direccion {get;set;}
        public string telefono {get;set;}
        public int id_puesto{get;set;}
        public string DPI {get;set;}
        public string fecha_nacimiento {get;set;}
        public string fecha_ingreso_registro {get;set;}
    }
}