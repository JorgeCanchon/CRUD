using Modelo;
using System.Collections.Generic;

namespace Logica.Interfaces
{
    public interface IRepositorio
    {
        bool Insertar(Modelo.Persona persona);
        bool Actualizar(Modelo.Persona persona);
        bool Eliminar(int idPersona);
        List<Modelo.Persona> GetPersonas();
        Modelo.Persona GetPersonaId(int idPersona);
    }
}
