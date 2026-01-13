using Dapper;
using ManejoPresupuestos.Models;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuestos.Servicios
{
    public interface IRepositoriosTiposCuentas
    {
        void Crear(TipoCuenta tipoCuenta);
    }
    public class RepositoriosTiposCuentas: IRepositoriosTiposCuentas
    {
        private readonly string connectionString;
        public RepositoriosTiposCuentas(IConfiguration configuration)
        {
                connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Crear(TipoCuenta tipoCuenta)
        {
            using var connection = new SqlConnection(connectionString);
            var id = connection.QuerySingle<int>($@"INSERT INTO TiposCuentas (Nombre, UsuarioId, Orden)
                                                  VALUES (@Nombre, @UsuarioId, 0);
                                                  SELECT SCOPE_IDENTITY();", tipoCuenta);
            tipoCuenta.Id = id;
        }
    }
}
