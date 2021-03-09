using Logica.Interfaces;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Infraestructura
{
    public class PersonaRepositorio : IPersonaRepositorio
    {
        private readonly SqlConnection _conexionDB;
        public PersonaRepositorio()
        {
            _conexionDB = ConexionDB.Conexion;
        }

        public bool Actualizar(Modelo.Persona persona)
        {
            bool seActualizo = false;
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = _conexionDB;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ActualizarPersona";
                command.Parameters.AddWithValue("@IdPersona", persona.IdPersona);
                command.Parameters.AddWithValue("@Nombres", persona.Nombres);
	            command.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                command.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento);
                command.Parameters.AddWithValue("@TipoIdentificacion", persona.TipoIdentificacion);
                command.Parameters.AddWithValue("@NumeroIdentificacion", persona.NumeroIdentificacion);

                if (!ConexionDB.ValidarConexionAbierta())
                    ConexionDB.Open();

                seActualizo = command.ExecuteNonQuery() > 0;
                ConexionDB.Close();
            }
            return seActualizo;
        }

        public bool Eliminar(int idPersona)
        {
            bool seElimino = false;
            using(SqlCommand command = new SqlCommand())
            {
                command.Connection = _conexionDB;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "EliminarPersona";
                command.Parameters.AddWithValue("@IdPersona", idPersona);

                if (!ConexionDB.ValidarConexionAbierta())
                    ConexionDB.Open();
                    
                seElimino = command.ExecuteNonQuery() > 0;
                ConexionDB.Close();

            }
            return seElimino;
        }

        public Modelo.Persona GetPersonaId(int idPersona)
        {
            DataTable datosPersona = new DataTable();
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = _conexionDB;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ObtenerPersonaPorId";
                command.Parameters.AddWithValue("@IdPersona", idPersona);

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(command))
                {
                    sqlAdapter.Fill(datosPersona);
                }
            };

            return datosPersona.AsEnumerable()
                .Select(x => new Modelo.Persona()
                {
                    IdPersona = (long)x["IdPersona"],
                    Nombres = x["Nombres"].ToString(),
                    Apellidos = x["Apellidos"].ToString(),
                    FechaNacimiento = (DateTime) x["FechaNacimiento"],
                    NumeroIdentificacion = (long) x["NumeroIdentificacion"],
                    TipoIdentificacion = x["TipoIdentificacion"].ToString(),
                    Edad = Convert.ToInt32((DateTime.Now - (DateTime)x["FechaNacimiento"]).TotalDays / 365)
                })
                .FirstOrDefault(); 
        }

        public List<Modelo.Persona> GetPersonas()
        {
            DataTable datosPersona = new DataTable();
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = _conexionDB;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ObtenerTodos";

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(command))
                {
                    sqlAdapter.Fill(datosPersona);
                }
            };

            return datosPersona.AsEnumerable()
                .Select(x => new Modelo.Persona()
                {
                    IdPersona = (long)x["IdPersona"],
                    Nombres = x["Nombres"].ToString(),
                    Apellidos = x["Apellidos"].ToString(),
                    FechaNacimiento = (DateTime)x["FechaNacimiento"],
                    NumeroIdentificacion = (long)x["NumeroIdentificacion"],
                    TipoIdentificacion = x["TipoIdentificacion"].ToString(),
                    Edad = Convert.ToInt32((DateTime.Now - (DateTime)x["FechaNacimiento"]).TotalDays / 365)
                })
                .ToList();
        }

        public bool Insertar(Modelo.Persona persona)
        {
            bool seInserto = false;
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = _conexionDB;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertarPersona";
                command.Parameters.AddWithValue("@Nombres", persona.Nombres);
                command.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                command.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento);
                command.Parameters.AddWithValue("@TipoIdentificacion", persona.TipoIdentificacion);
                command.Parameters.AddWithValue("@NumeroIdentificacion", persona.NumeroIdentificacion);

                if(!ConexionDB.ValidarConexionAbierta())
                    ConexionDB.Open();
                seInserto = command.ExecuteNonQuery() > 0;
                ConexionDB.Close();
            }
            return seInserto;
        }
    }
}
