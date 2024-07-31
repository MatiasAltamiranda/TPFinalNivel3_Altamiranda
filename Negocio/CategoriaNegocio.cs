using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
			List<Categoria> listaCategoria = new List<Categoria>();
			ConexionDB conexionDB = new ConexionDB();


			try
			{
				conexionDB.setearConsulta("Select Id, Descripcion from CATEGORIAS");
				conexionDB.ejecutarLectura();

				while(conexionDB.Lector.Read())
				{
                    Categoria categoria = new Categoria();
                    categoria.Id = (int)conexionDB.Lector["Id"];
                    categoria.Descripcion = (string)conexionDB.Lector["Descripcion"];
                    listaCategoria.Add(categoria);
                }

				return listaCategoria;
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
