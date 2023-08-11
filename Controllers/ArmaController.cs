using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PruebaAPi.Entity;
using System.Collections.ObjectModel;

namespace PruebaAPi.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/Arma")]
    [ApiController]
    public class ArmaController : Controller
    {
        [HttpGet("GetArma")]
        public Collection<ArmaEN> Get()
        {

            var lista = new Collection<ArmaEN>();
            
            lista = null;
            using (var cnn = new SqlConnection(UI.CadenaSQL))
            {
                using (var adaptador = new SqlDataAdapter("select  a.idarma,a.arma, a.precio, a.balas, a.municion, c.categoria from arma as a , categoria as c where a.idcategoria = c.idcategoria ", cnn))
                {
                    cnn.Open();
                    var reader = adaptador.SelectCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var objE = new ArmaEN();

                        objE.idarma = reader.GetInt32(0);
                        objE.arma = reader.GetString(1);
                        objE.precio = reader.GetInt32(2);
                        objE.balas = reader.GetInt32(3);
                        objE.municion = reader.GetInt32(4);
                        objE.categoria = reader.GetString(5);
                        lista.Add(objE);

                    }
                    cnn.Close();
                }
            }



            return lista;
        }


        [HttpGet("BuscarArma")]
        public Collection<ArmaEN> BuscarAgenteGet(string arma)
        {

            var lista = new Collection<ArmaEN>();

            
            using (var cnn = new SqlConnection(UI.CadenaSQL))
            {
                using (var adaptador = new SqlDataAdapter("select  a.idarma,a.arma, a.precio, a.balas, a.municion, c.categoria from arma as a , categoria as c where a.idcategoria = c.idcategoria and a.arma= '"+arma+"'", cnn))
                {
                    cnn.Open();
                    var reader = adaptador.SelectCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var objE = new ArmaEN();

                        objE.idarma = reader.GetInt32(0);
                        objE.arma = reader.GetString(1);
                        objE.precio = reader.GetInt32(2);
                        objE.balas = reader.GetInt32(3);
                        objE.municion = reader.GetInt32(4);
                        objE.categoria = reader.GetString(5);
                        lista.Add(objE);

                    }
                    cnn.Close();
                }
            }



            return lista;
        }






    }


}
