using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public int registrarUsuario(Usuario nuevo)
        {
			ConexionDB conexionDB = new ConexionDB();
			try
			{
                conexionDB.setearConsulta("Insert into ARTICULOS (Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) values (@Codigo,@Nombre,@Descripcion,@IdMarca, @IdCategoria,@ImagenUrl,@Precio)");
                conexionDB.setearConsulta("insert into USERS (nombre,apellido,email,pass,admin) output inserted.id values (@nombre,@apellido,@email,@pass, 0) ");
				conexionDB.setearParametro("@nombre", nuevo.Nombre);
                conexionDB.setearParametro("@apellido", nuevo.Apellido);
                conexionDB.setearParametro("@email", nuevo.Email);
                conexionDB.setearParametro("@pass", nuevo.Pass);
                return conexionDB.ejecutarAccionScalar();
			}
			catch (Exception ex)
			{

				throw ex;
			}
            finally
            {
                conexionDB.cerrarConexion();
            }
        }
    }
}
