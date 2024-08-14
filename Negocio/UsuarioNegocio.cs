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

        public bool login(Usuario usuario)
        {
            ConexionDB conexionDB= new ConexionDB();

            try
            {
                conexionDB.setearConsulta("select id, email,pass,admin,nombre,apellido,urlImagenPerfil from USERS where email=@email and pass = @pass");
                conexionDB.setearParametro("@email", usuario.Email);
                conexionDB.setearParametro("@pass", usuario.Pass);
                conexionDB.ejecutarLectura();
                if (conexionDB.Lector.Read())
                {
                    usuario.Id = (int)conexionDB.Lector["id"];
                    usuario.Admin = (bool)conexionDB.Lector["admin"];
                    if (!(conexionDB.Lector["nombre"] is DBNull))
                    {
                        usuario.Nombre = (string)conexionDB.Lector["nombre"];
                    }
                    if (!(conexionDB.Lector["Apellido"] is DBNull))
                    {
                        usuario.Apellido = (string)conexionDB.Lector["apellido"];
                    }
                    if (!(conexionDB.Lector["urlImagenPerfil"] is DBNull))
                    {
                        usuario.UrlImagen = (string)conexionDB.Lector["urlImagenPerfil"];
                    }
                    return true;
                }
                return false;
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

        public void actualizar(Usuario usuario)
        {
            ConexionDB conexionDB = new ConexionDB();
            try
            {
                conexionDB.setearConsulta("Update USERS set urlImagenPerfil =@imagen , nombre =@nombre, apellido=@apellido where id=@id");
                conexionDB.setearParametro("@imagen", (object)usuario.UrlImagen ?? DBNull.Value);
                conexionDB.setearParametro("@nombre", usuario.Nombre);
                conexionDB.setearParametro("@apellido", usuario.Apellido);
                conexionDB.setearParametro("@id", usuario.Id);
                conexionDB.ejecutarAccion();
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
