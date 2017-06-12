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
            catch (Exception)
            {
                resultado.error = "Error";
            }
            resultado.totalElementos = data.Count;
            resultado.data = data;
            Db.Desconectar();
            return resultado;
        }

        // GET: api/TiposAnimal/5
        public RespuestaApi<TiposAnimal> Get(int id)
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
            catch (Exception)
            {
                resultado.error = "Error";
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
        public RespuestaApi<TiposAnimal> Put(int id, [FromBody] TiposAnimal tipoAnimal)
        {
            RespuestaApi<TiposAnimal> resultado = new RespuestaApi<TiposAnimal>();
            return resultado;
        }

        // DELETE: api/TiposAnimal/5
        [HttpDelete]
        public RespuestaApi<TiposAnimal> Delete(int id)
        {
            RespuestaApi<TiposAnimal> resultado = new RespuestaApi<TiposAnimal>();
            return resultado;
        }
    }
}
