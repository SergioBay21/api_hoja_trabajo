using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using web_api_db.Models;
namespace web_api_db.Controllers{
    [Route("api/[controller]")]
    public class EmpleadosController : Controller{
        private Conexion dbConexion;
        public EmpleadosController(){
            dbConexion=Conectar.Create();
        }
        [HttpGet]
        public ActionResult Get(){
            return Ok(dbConexion.Empleados.ToArray());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id){
            var empleado = await dbConexion.Empleados.FindAsync(id);
            if (empleado !=null){
                return Ok(empleado);
            }else {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Empleados empleado){
            if(ModelState.IsValid){
                dbConexion.Empleados.Add(empleado);
                await dbConexion.SaveChangesAsync();
                return Ok(empleado);
            }else{
                return NotFound();
            }
        }
        [HttpPut]
        public async Task <ActionResult> Put([FromBody] Empleados empleado){
            var v_empleados = dbConexion.Empleados.SingleOrDefault(a => a.id_empleados == empleado.id_empleados);
            if (v_empleados !=null && ModelState.IsValid){
                dbConexion.Entry(v_empleados).CurrentValues.SetValues(empleado);
                await dbConexion.SaveChangesAsync();
                return Ok();

            }else{
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public async Task <ActionResult> Delete(int id){
            var empleado = dbConexion.Empleados.SingleOrDefault(a => a.id_empleados == id);
            if (empleado !=null){
                dbConexion.Empleados.Remove(empleado);
                await dbConexion.SaveChangesAsync();
                return Ok();
            }else{
                return NotFound();
            }
        }
    }
}