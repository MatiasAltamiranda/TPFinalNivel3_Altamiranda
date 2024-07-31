using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
			List<Marca > listaMarca = new List<Marca>();
			ConexionDB conexionDB = new ConexionDB();

			try
			{
				conexionDB.setearConsulta("Select Id, Descripcion from MARCAS");
				conexionDB.ejecutarLectura();

				while(conexionDB.Lector.Read()) { 
				
				 Marca marca = new Marca();
					marca.Id = (int)conexionDB.Lector["Id"];
					marca.Descripcion = (string)conexionDB.Lector["Descripcion"];
					listaMarca.Add(marca);
				}

				return listaMarca;
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
