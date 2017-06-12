using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Zoo.db;

namespace Zoo
{
    public class ClasificacionesController : ApiController
    {
        // GET: api/Clasificaciones
        public RespuestaApi<Clasificaciones> Get()
        {
            RespuestaApi<Clasificaciones> resultado = new RespuestaApi<Clasificaciones>();
            List<Clasificaciones> data = new List<Clasificaciones>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    data = Db.ListaClasificaciones();
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

        // GET: api/Clasificaciones/5
        public RespuestaApi<Clasificaciones> Get(int id)
        {
            RespuestaApi<Clasificaciones> resultado = new RespuestaApi<Clasificaciones>();
            List<Clasificaciones> data = new List<Clasificaciones>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    data = Db.ListaClasificacionesId(id);
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

        // POST: api/Clasificaciones
        [HttpPost]
        public IHttpActionResult Post([FromBody] Clasificaciones clasificacion)
        {
            RespuestaApi<Clasificaciones> resultado = new RespuestaApi<Clasificaciones>();
            return Ok(resultado);
        }

        // PUT: api/Clasificaciones/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Clasificaciones clasificacion)
        {
            RespuestaApi<Clasificaciones> respuesta = new RespuestaApi<Clasificaciones>();
            respuesta.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.ActualizarClasificaciones(id, clasificacion);
                }
                respuesta.totalElementos = filasAfectadas;
                Db.Desconectar();
            }
            catch (Exception)
            {
                respuesta.totalElementos = 0;
                respuesta.error = "Error al eliminar la marca";
            }
            return Ok(respuesta);
        }

        // DELETE: api/Clasificaciones/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
