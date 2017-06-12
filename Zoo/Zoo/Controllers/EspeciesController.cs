using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Zoo.db;

namespace Zoo.Controllers
{
    public class EspeciesController : ApiController
    {
        // GET: api/Especies
        public RespuestaApi<Especies> Get()
        {
            RespuestaApi<Especies> resultado = new RespuestaApi<Especies>();
            List<Especies> data = new List<Especies>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    data = Db.ListaEspecies();
                    resultado.error = "";
                }
            }
            catch (Exception)
            {
                resultado.error = "Error";
            }
            resultado.totalElementos = data.Count;
            resultado.data = data;
            Db.Desconectar();
            return resultado;
        }

        // GET: api/Especies/5
        public RespuestaApi<Especies> Get(int id)
        {
            RespuestaApi<Especies> resultado = new RespuestaApi<Especies>();
            List<Especies> data = new List<Especies>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    data = Db.ListaEspeciesId(id);
                    resultado.error = "";
                }
            }
            catch (Exception)
            {
                resultado.error = "Error";
            }
            resultado.totalElementos = data.Count;
            resultado.data = data;
            Db.Desconectar();
            return resultado;
        }

        // POST: api/Especies
        [HttpPost]
        public RespuestaApi<Especies> Post([FromBody] Especies especie)
        {/*http://bitacoraweb.info/como-cargar-dinamicamente-un-select-con-jquery-javascript/*/
            RespuestaApi<Especies> resultado = new RespuestaApi<Especies>();
            List<Especies> data = new List<Especies>();
            return resultado;
        }

        // PUT: api/Especies/5
        [HttpPut]
        public RespuestaApi<Especies> Put(int id, [FromBody] Especies especie)
        {
            RespuestaApi<Especies> resultado = new RespuestaApi<Especies>();
            List<Especies> data = new List<Especies>();
        }

        // DELETE: api/Especies/5
        [HttpDelete]
        public RespuestaApi<Especies> Delete(int id)
        {
            RespuestaApi<Especies> resultado = new RespuestaApi<Especies>();
            List<Especies> data = new List<Especies>();
        }
    }
}
