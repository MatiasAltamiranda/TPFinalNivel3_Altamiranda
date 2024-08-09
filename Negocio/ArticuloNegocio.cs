using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar(string id="")
        { 

        List<Articulo> listaArticulos = new List<Articulo>();
        ConexionDB conexionDB = new ConexionDB();

            try
            {
                if(id!= "")
                {
                    conexionDB.setearConsulta("select A.Id,Codigo,Nombre,A.Descripcion,M.Descripcion Marca,C.Descripcion Categoria,ImagenUrl, Precio,C.id IdCategoria,M.Id IdMarca from ARTICULOS A, CATEGORIAS C, MARCAS M Where A.IdCategoria = C.Id and A.IdMarca = M.Id and A.Id= " + id);
                }
                else
                {
                    conexionDB.setearConsulta("select A.Id,Codigo,Nombre,A.Descripcion,M.Descripcion Marca,C.Descripcion Categoria,ImagenUrl, Precio,C.id IdCategoria,M.Id IdMarca from ARTICULOS A, CATEGORIAS C, MARCAS M Where A.IdCategoria = C.Id and A.IdMarca = M.Id");
                }

                conexionDB.ejecutarLectura();
                while (conexionDB.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)conexionDB.Lector["Id"];
                    articulo.Codigo = (string)conexionDB.Lector["Codigo"];
                    articulo.Nombre = (string)conexionDB.Lector["Nombre"];
                    articulo.Descripcion = (string)conexionDB.Lector["Descripcion"];
                    articulo.Marca = new Marca();
                    articulo.Marca.Id = (int)conexionDB.Lector["IdMarca"];
                    articulo.Marca.Descripcion = (string)conexionDB.Lector["Marca"];
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = (int)conexionDB.Lector["IdCategoria"];
                    articulo.Categoria.Descripcion = (string)conexionDB.Lector["Categoria"];
                    articulo.ImagenUrl = (string)conexionDB.Lector["ImagenUrl"];
                    articulo.Precio = Math.Round((decimal)conexionDB.Lector["Precio"],2);
                    listaArticulos.Add(articulo);
              
                }
                 return listaArticulos;
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

        public void agregar(Articulo articulo)
        {
            ConexionDB conexionDB = new ConexionDB();
            try
            {
                conexionDB.setearConsulta("Insert into ARTICULOS (Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) values (@Codigo,@Nombre,@Descripcion,@IdMarca, @IdCategoria,@ImagenUrl,@Precio)");
                conexionDB.setearParametro("@Codigo", articulo.Codigo);
                conexionDB.setearParametro("@Nombre", articulo.Nombre);
                conexionDB.setearParametro("@Descripcion", articulo.Descripcion);
                conexionDB.setearParametro("@IdMarca", articulo.Marca.Id);
                conexionDB.setearParametro("@IdCategoria", articulo.Categoria.Id);
                conexionDB.setearParametro("@ImagenUrl", articulo.ImagenUrl);
                conexionDB.setearParametro("@Precio", articulo.Precio);
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

        public void eliminar(int id)
        {
            try
            {
                ConexionDB conexionDB = new ConexionDB();
                conexionDB.setearConsulta("Delete from ARTICULOS where id=@id");
                conexionDB.setearParametro("@id", id);
                conexionDB.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public void modificar(Articulo articulo)
        {
            ConexionDB conexionDB = new ConexionDB();

            try
            {
                conexionDB.setearConsulta("update ARTICULOS set Codigo=@codigo,Nombre=@nombre,Descripcion=@descripcion,IdMarca =@idMarca,IdCategoria=@idCategoria,ImagenUrl=@imagen,Precio=@precio where id=@id");
                conexionDB.setearParametro("@codigo", articulo.Codigo);
                conexionDB.setearParametro("@nombre", articulo.Nombre);
                conexionDB.setearParametro("@descripcion", articulo.Descripcion);
                conexionDB.setearParametro("@idMarca", articulo.Marca.Id);
                conexionDB.setearParametro("@idCategoria", articulo.Categoria.Id);
                conexionDB.setearParametro("@imagen", articulo.ImagenUrl);
                conexionDB.setearParametro("@precio", articulo.Precio);
                conexionDB.setearParametro("@id", articulo.Id);
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

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            ConexionDB conexion = new ConexionDB();

            try
            {
                string consulta ="select A.Id,Codigo,Nombre,A.Descripcion,M.Descripcion Marca,C.Descripcion Categoria,ImagenUrl, Precio,C.id IdCategoria,M.Id IdMarca from ARTICULOS A, CATEGORIAS C, MARCAS M Where A.IdCategoria = C.Id and A.IdMarca = M.Id and ";

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtro;
                            break;
                        default:
                            consulta += "Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "Marca")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "M.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "M.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "M.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "C.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "C.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "C.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }

                conexion.setearConsulta(consulta);
                conexion.ejecutarLectura();

                while (conexion.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)conexion.Lector["Id"];
                    articulo.Codigo = (string)conexion.Lector["Codigo"];
                    articulo.Nombre = (string)conexion.Lector["Nombre"];
                    articulo.Descripcion = (string)conexion.Lector["Descripcion"];
                    articulo.Marca = new Marca();
                    articulo.Marca.Id = (int)conexion.Lector["IdMarca"];
                    articulo.Marca.Descripcion = (string)conexion.Lector["Marca"];
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = (int)conexion.Lector["IdCategoria"];
                    articulo.Categoria.Descripcion = (string)conexion.Lector["Categoria"];
                    articulo.ImagenUrl = (string)conexion.Lector["ImagenUrl"];
                    articulo.Precio = Math.Round((decimal)conexion.Lector["Precio"], 2);
                    lista.Add(articulo);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
