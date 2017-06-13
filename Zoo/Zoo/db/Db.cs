using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Zoo.db
{
    public static class Db
    {
        static SqlConnection conexion = null;

        public static void Conectar()
        {
            conexion = new SqlConnection();
            try
            {
                string cadenaConexion = @"Server=.\SQLEXPRESS;
                                        Database=zoodb;
                                        User Id=testuser;
                                        Password = !Curso@2017; ";

                conexion.ConnectionString = cadenaConexion;
                conexion.Open();
                Console.WriteLine("Estado de la conexión: " + conexion.State.ToString());
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Sql exception " + ex.ToString());
                Desconectar();
            }
            catch (Exception ex2)
            {
                Console.WriteLine("Exception " + ex2.ToString());
                Desconectar();
            }
        }

        public static bool EstaLaConexionAbierta()
        {
            return conexion.State == ConnectionState.Open;
        }

        public static void Desconectar()
        {
            if (conexion != null)
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    Console.WriteLine("Nombre de la base de datos " + conexion.Database.ToString());
                    conexion.Close();
                    Console.WriteLine("Conexión cerrada con éxito");
                }
                conexion.Dispose();
                conexion = null;
            }
        }
        
        /*------------------------------- Especies --------------------------------------*/
        public static List<Especies> ListaEspecies()
        {
            List<Especies> resultados = new List<Especies>();
            string procedimientoAEjecutar = "dbo.Get_Especies";
            SqlCommand comando = new SqlCommand(procedimientoAEjecutar, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Especies especie = new Especies();
                especie.idEspecie = (long)reader["idEspecie"];
                especie.clasificacion = new Clasificaciones();
                especie.clasificacion.idClasificacion = (int)reader["idClasificacion"];
                especie.clasificacion.denominacion = reader["ClasificacionDenominacion"].ToString();
                especie.tipoAnimal = new TiposAnimal();
                especie.tipoAnimal.idTipoAnimal = (long)reader["idTipoAnimal"];
                especie.tipoAnimal.denominacion = reader["AnimalDenominacion"].ToString();
                especie.nombre = reader["nombre"].ToString();
                especie.nPatas = (short)reader["nPatas"];
                especie.esMascota = (bool)reader["esMascotas"];
                resultados.Add(especie);
            }
            reader.Close();
            return resultados;
        }

        public static List<Especies> ListaEspeciesId(long id) {
            List<Especies> resultados = new List<Especies>();
            string procedimientoAEjecutar = "dbo.Get_Especies_Id";
            SqlCommand comando = new SqlCommand(procedimientoAEjecutar,conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idEspecie";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);

            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read()) {
                Especies especie = new Especies();
                especie.idEspecie = (long) reader["idEspecie"];
                especie.clasificacion = new Clasificaciones();
                especie.clasificacion.idClasificacion = (int) reader["idClasificacion"];
                especie.clasificacion.denominacion = reader["ClasificacionDenominacion"].ToString();
                especie.tipoAnimal = new TiposAnimal();
                especie.tipoAnimal.idTipoAnimal = (long) reader["idTipoAnimal"];
                especie.tipoAnimal.denominacion = reader["AnimalDenominacion"].ToString();
                especie.nombre = reader["nombre"].ToString();
                especie.nPatas = (short) reader["nPatas"];
                especie.esMascota = (bool) reader["esMascotas"];
                resultados.Add(especie);
            }
            reader.Close();
            return resultados;
        }

        public static int ActualizarEspecie(long id) {
            throw new NotImplementedException();
        }

        public static int EliminarEspecie(long id)
        {
            string procedimiento = "dbo.EliminarEspecie";

            SqlCommand comando = new SqlCommand(procedimiento,conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "idEspecie";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = id;

            comando.Parameters.Add(parametro);

            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        /*--------------------------------- TipoAnimal ----------------------------------*/
        public static List<TiposAnimal> ListaTiposAnimal()
        {
            List<TiposAnimal> resultados = new List<TiposAnimal>();
            string procedimientoAEjecutar = "dbo.Get_TiposAnimal";
            SqlCommand comando = new SqlCommand(procedimientoAEjecutar, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                TiposAnimal tiposAnimal = new TiposAnimal();
                tiposAnimal.idTipoAnimal = (long)reader["idTipoAnimal"];
                tiposAnimal.denominacion = reader["denominacion"].ToString();
                resultados.Add(tiposAnimal);
            }
            reader.Close();
            return resultados;
        }

        public static List<TiposAnimal> ListaTiposAnimalId(long id)
        {
            List<TiposAnimal> resultados = new List<TiposAnimal>();
            string procedimientoAEjecutar = "dbo.Get_TiposAnimal_Id";
            SqlCommand comando = new SqlCommand(procedimientoAEjecutar, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idTipoAnimal";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);

            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                TiposAnimal tiposAnimal = new TiposAnimal();
                tiposAnimal.idTipoAnimal = (long)reader["idTipoAnimal"];
                tiposAnimal.denominacion = reader["denominacion"].ToString();
                resultados.Add(tiposAnimal);
            }
            reader.Close();
            return resultados;
        }

        public static int ActualizarTipoAnimal(long id,TiposAnimal tipoAnimal) {

            string procedimiento = "dbo.ActualizarTiposAnimal";

            SqlCommand comando = new SqlCommand(procedimiento,conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idTipoAnimal";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            
            SqlParameter parametroDenominacion = new SqlParameter();
            parametroDenominacion.ParameterName = "denominacion";
            parametroDenominacion.SqlDbType = SqlDbType.NVarChar;
            parametroDenominacion.SqlValue = tipoAnimal.denominacion;
            
            comando.Parameters.Add(parametroId);
            comando.Parameters.Add(parametroDenominacion);

            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static int EliminarTipoAnimal(long id) 
        {
            string procedimiento = "dbo.EliminarTipoAnimal";

            SqlCommand comando = new SqlCommand(procedimiento,conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "idTipoAnimal";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = id;

            comando.Parameters.Add(parametro);

            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        /*----------------------------- Clasificaciones ---------------------------------*/
        public static List<Clasificaciones> ListaClasificaciones()
        {
            List<Clasificaciones> resultados = new List<Clasificaciones>();
            string procedimientoAEjecutar = "dbo.Get_Clasificaciones";
            SqlCommand comando = new SqlCommand(procedimientoAEjecutar, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Clasificaciones clasificacion = new Clasificaciones();
                clasificacion.idClasificacion = (int)reader["idClasificacion"];
                clasificacion.denominacion = reader["denominacion"].ToString();
                resultados.Add(clasificacion);
            }
            reader.Close();
            return resultados;
        }
        
        public static List<Clasificaciones> ListaClasificacionesId(int id)
        {
            List<Clasificaciones> resultados = new List<Clasificaciones>();
            string procedimientoAEjecutar = "dbo.Get_Clasificaciones_Id";
            SqlCommand comando = new SqlCommand(procedimientoAEjecutar, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idClasificacion";
            parametroId.SqlDbType = SqlDbType.Int;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);
            
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Clasificaciones clasificacion = new Clasificaciones();
                clasificacion.idClasificacion = (int)reader["idClasificacion"];
                clasificacion.denominacion = reader["denominacion"].ToString();
                resultados.Add(clasificacion);
            }
            reader.Close();
            return resultados;
        }

        public static int InsertarClasificacion(Clasificaciones clasificacion) {
            string respuesta = "";
            int filaAfectadas;
            try {
                string procedimientoAEjecutar = "dbo.InsertarClasificacion";
                
                SqlCommand comando = new SqlCommand(procedimientoAEjecutar,conexion);
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parametroDenominacion = new SqlParameter();
                parametroDenominacion.ParameterName = "denominacion";
                parametroDenominacion.SqlDbType = SqlDbType.NVarChar;
                parametroDenominacion.SqlValue = clasificacion.denominacion;

                comando.Parameters.Add(parametroDenominacion);
                filaAfectadas = comando.ExecuteNonQuery();

            } catch (SqlException ex) {
                respuesta = "Error al insertar: " + ex.ToString();
                filaAfectadas = -1;
            } catch (Exception ex) {
                respuesta = "Error al insertar: " + respuesta + " " + ex.ToString();
                filaAfectadas = -1;
            }
            return filaAfectadas;
        }
        public static int ActualizarClasificaciones(int id, Clasificaciones clasificacion)
        {
            string procedimiento = "dbo.ActualizarClasificaciones";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idClasificacion";
            parametroId.SqlDbType = SqlDbType.Int;
            parametroId.SqlValue = id;
            
            SqlParameter parametroDenominacion = new SqlParameter();
            parametroDenominacion.ParameterName = "denominacion";
            parametroDenominacion.SqlDbType = SqlDbType.NVarChar;
            parametroDenominacion.SqlValue = clasificacion.denominacion;
            
            comando.Parameters.Add(parametroId);
            comando.Parameters.Add(parametroDenominacion);

            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static int EliminarClasificacion(int id)
        {
            string procedimiento = "dbo.EliminarClasificaciones";

            SqlCommand comando = new SqlCommand(procedimiento,conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "idClasificacion";
            parametro.SqlDbType = SqlDbType.Int;
            parametro.SqlValue = id;

            comando.Parameters.Add(parametro);

            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }
    }
}