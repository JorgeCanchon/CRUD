using Logica.Interfaces;
using Modelo;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class PersonaManager
    {
        private readonly IPersonaRepositorio _personaRepository;

        public PersonaManager(IPersonaRepositorio personaRepository)
        {
            _personaRepository = personaRepository ?? throw new ArgumentNullException(nameof(personaRepository));
        }

        public bool InsertarPersona(Persona persona)
        {
            try
            {
                return _personaRepository.Insertar(persona);
            }
            catch
            {
                return false;
            }
        }

        public List<Persona> ObtenerTodos()
        {
            try
            {
                return _personaRepository.GetPersonas();
            }
            catch
            {
                return null;
            }
        }

        public bool EliminarPersona(int id) 
        {
            try 
            {
                return _personaRepository.Eliminar(id);
            }
            catch
            {
                return false;
            }
        }

        public bool ActualizarPersona(Persona persona)
        {
            try
            {
                return _personaRepository.Actualizar(persona);
            }
            catch
            {
                return false;
            }
        }

    }
}
