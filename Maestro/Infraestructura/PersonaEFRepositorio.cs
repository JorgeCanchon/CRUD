using Logica.Interfaces;
using Modelo;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace Infraestructura
{
    public class PersonaEFRepositorio : IPersonaRepositorio
    {
        private readonly maestropersonaEntities dbContext;

        public PersonaEFRepositorio()
        {
            dbContext = new maestropersonaEntities();
        }
        public bool Actualizar(Modelo.Persona persona)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int idPersona)
        {
            try
            {
                dbContext.Personas.Remove(null);
                return true;
            }catch
            {
                return false;
            }
        }

        public Modelo.Persona GetPersonaId(int idPersona)
        {
            throw new NotImplementedException();
        }

        public List<Modelo.Persona> GetPersonas()
        {
            throw new NotImplementedException();
        }

        public bool Insertar(Modelo.Persona persona)
        {
            try
            {
                var entity = new Persona()
                {
                    Nombres = persona.Nombres,
                    Apellidos = persona.Apellidos,
                    FechaNacimiento = persona.FechaNacimiento,
                    TipoIdentificacion = persona.TipoIdentificacion,
                    NumeroIdentificacion = persona.NumeroIdentificacion
                };

                dbContext.Personas.Add(entity);
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
    }
}
