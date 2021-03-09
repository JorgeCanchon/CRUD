using System.Data;
using System.Data.SqlClient;

namespace Infraestructura
{
    public class ConexionDB
    {
        private static SqlConnection _instancia = null;
        private static readonly string conexionString = "Password=Rw731!2_1DQi;Persist Security Info=True;User ID=maestropersona;Initial Catalog=maestropersona;Data Source=den1.mssql7.gear.host;";

        private ConexionDB()
        {

        }

        public static SqlConnection Conexion
        {
            get
            {
                if(_instancia == null)
                {
                    _instancia = new SqlConnection(conexionString);
                }
                return _instancia;
            }
        }

        public static void Open()
        {
            if (_instancia != null)
                _instancia.Open();
        }

        public static bool ValidarConexionAbierta()
        {
            return _instancia.State == ConnectionState.Open;
        }

        public static void Close()
        {
            if (_instancia != null)
                _instancia.Close();
        }
    }
}
