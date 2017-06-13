using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Zoo.db;

namespace Zoo
{
    public class TiposAnimalController : ApiController
    {
        // GET: api/TiposAnimal
        public RespuestaApi<TiposAnimal> Get()
        {
            RespuestaApi<TiposAnimal> resultado = new RespuestaApi<TiposAnimal>();
            List<TiposAnimal> data = new List<TiposAnimal>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    data = Db.ListaTiposAnimal();
                    resultado.error = "";
                }
            }
            catch (Exception ex)
            {
                resultado.error = "Error " + ex.ToString();
            }
            resultado.totalElementos = data.Count;
            resultado.data = data;
            Db.Desconectar();
            return resultado;
        }

        // GET: api/TiposAnimal/5
        public RespuestaApi<TiposAnimal> Get(long id)
        {
            RespuestaApi<TiposAnimal> resultado = new RespuestaApi<TiposAnimal>();
            List<TiposAnimal> data = new List<TiposAnimal>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    data = Db.ListaTiposAnimalId(id);
                    resultado.error = "";
                }
            }
            catch (Exception ex)
            {
                resultado.error = "Error " + ex.ToString();
            }
            resultado.totalElementos = data.Count;
            resultado.data = data;
            Db.Desconectar();
            return resultado;
        }

        // POST: api/TiposAnimal
        [HttpPost]
        public RespuestaApi<TiposAnimal> Post([FromBody] TiposAnimal tipoAnimal)
        {
            RespuestaApi<TiposAnimal> resultado = new RespuestaApi<TiposAnimal>();
            return resultado;
        }

        // PUT: api/TiposAnimal/5
        [HttpPut]
        public IHttpActionResult Put(long id,[FromBody] TiposAnimal tipoAnimal) {

            RespuestaApi<TiposAnimal> respuesta = new RespuestaApi<TiposAnimal>();
            respuesta.error = "";
            int filasAfectadas = 0;
            try {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta()) {
                    filasAfectadas = Db.ActualizarTipoAnimal(id,tipoAnimal);
                }
                respuesta.totalElementos = filasAfectadas;
                Db.Desconectar();
            } catch (Exception ex) {
                respuesta.totalElementos = 0;
                respuesta.error = "Error al actualizar TipoAnimal con id " + id.ToString() + " ERROR: " + ex.ToString();
            }
            return Ok(respuesta);
        }

        // DELETE: api/TiposAnimal/5
        [HttpDelete]
        public IHttpActionResult Delete(long id)
        {
            RespuestaApi<TiposAnimal> respuesta = new RespuestaApi<TiposAnimal>();
            respuesta.error = "";
            int filasAfectadas = 0;
            try {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta()) {
                    filasAfectadas = Db.EliminarTipoAnimal(id);
                }
                respuesta.totalElementos = filasAfectadas;
                Db.Desconectar();
            } catch (Exception ex) {
                respuesta.totalElementos = 0;
                respuesta.error = "Error al eliminar TipoAnimal con id " +id.ToString() + " ERROR: "+ex.ToString();
            }
            return Ok(respuesta);
        }
    }
}
