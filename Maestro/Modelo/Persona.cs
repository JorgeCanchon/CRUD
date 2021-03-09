using System;

namespace Modelo
{
    public class Persona
    {
        public long IdPersona { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TipoIdentificacion { get; set; }
        public long NumeroIdentificacion { get;set; }
        public int Edad { get;set; }
    }
}
