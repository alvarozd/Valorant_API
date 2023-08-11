using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PruebaAPi.Entity;
using System.Collections.ObjectModel;

namespace PruebaAPi.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/Agente")]
    [ApiController]
    public class AgenteController : ControllerBase
    {
        [HttpGet("GetAgente")]
        public Collection<AgenteEN> Get()
        {

            var lista = new Collection<AgenteEN>();
            using (var cnn = new SqlConnection(UI.CadenaSQL))
            {
                using (var adaptador = new SqlDataAdapter("Select  a.idagente,  a.agente, b.nacionalidad,a.img from Agente as a, nacionalidad as b where a.idnacionalidad=b.idnacionalidad", cnn))
                {
                    cnn.Open();
                    var reader = adaptador.SelectCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var objE = new AgenteEN();

                        objE.idagente = reader.GetInt32(0);
                        objE.agente = reader.GetString(1);
                        objE.nacionalidad = reader.GetString(2);
                        objE.img = reader.GetString(3);
                        lista.Add(objE);

                    }
                    cnn.Close();
                }
            }



            return lista;
        }
    }

    public static class UI
    {
        public static string CadenaSQL { get; set; } = string.Empty;
    }
}
