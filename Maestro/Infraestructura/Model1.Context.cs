//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infraestructura
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class maestropersonaEntities : DbContext
    {
        public maestropersonaEntities()
            : base("name=maestropersonaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Persona> Personas { get; set; }
    
        public virtual int ActualizarPersona(Nullable<long> idPersona, string nombres, string apellidos, Nullable<System.DateTime> fechaNacimiento, string tipoIdentificacion, Nullable<long> numeroIdentificacion)
        {
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("IdPersona", idPersona) :
                new ObjectParameter("IdPersona", typeof(long));
    
            var nombresParameter = nombres != null ?
                new ObjectParameter("Nombres", nombres) :
                new ObjectParameter("Nombres", typeof(string));
    
            var apellidosParameter = apellidos != null ?
                new ObjectParameter("Apellidos", apellidos) :
                new ObjectParameter("Apellidos", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento.HasValue ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(System.DateTime));
    
            var tipoIdentificacionParameter = tipoIdentificacion != null ?
                new ObjectParameter("TipoIdentificacion", tipoIdentificacion) :
                new ObjectParameter("TipoIdentificacion", typeof(string));
    
            var numeroIdentificacionParameter = numeroIdentificacion.HasValue ?
                new ObjectParameter("NumeroIdentificacion", numeroIdentificacion) :
                new ObjectParameter("NumeroIdentificacion", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ActualizarPersona", idPersonaParameter, nombresParameter, apellidosParameter, fechaNacimientoParameter, tipoIdentificacionParameter, numeroIdentificacionParameter);
        }
    
        public virtual int EliminarPersona(Nullable<long> idPersona)
        {
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("IdPersona", idPersona) :
                new ObjectParameter("IdPersona", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EliminarPersona", idPersonaParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> InsertarPersona(string nombres, string apellidos, Nullable<System.DateTime> fechaNacimiento, string tipoIdentificacion, Nullable<long> numeroIdentificacion)
        {
            var nombresParameter = nombres != null ?
                new ObjectParameter("Nombres", nombres) :
                new ObjectParameter("Nombres", typeof(string));
    
            var apellidosParameter = apellidos != null ?
                new ObjectParameter("Apellidos", apellidos) :
                new ObjectParameter("Apellidos", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento.HasValue ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(System.DateTime));
    
            var tipoIdentificacionParameter = tipoIdentificacion != null ?
                new ObjectParameter("TipoIdentificacion", tipoIdentificacion) :
                new ObjectParameter("TipoIdentificacion", typeof(string));
    
            var numeroIdentificacionParameter = numeroIdentificacion.HasValue ?
                new ObjectParameter("NumeroIdentificacion", numeroIdentificacion) :
                new ObjectParameter("NumeroIdentificacion", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("InsertarPersona", nombresParameter, apellidosParameter, fechaNacimientoParameter, tipoIdentificacionParameter, numeroIdentificacionParameter);
        }
    
        public virtual ObjectResult<ObtenerPersonaPorId_Result> ObtenerPersonaPorId(Nullable<long> idPersona)
        {
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("IdPersona", idPersona) :
                new ObjectParameter("IdPersona", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ObtenerPersonaPorId_Result>("ObtenerPersonaPorId", idPersonaParameter);
        }
    
        public virtual ObjectResult<ObtenerTodos_Result> ObtenerTodos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ObtenerTodos_Result>("ObtenerTodos");
        }
    }
}
