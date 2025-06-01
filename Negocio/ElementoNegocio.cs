using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class ElementoNegocio
    {
       
       AccesoDatos datos = new AccesoDatos();

        public List<Elemento> listar() 
        {
            try
            {
                List<Elemento> listaElementos = new List<Elemento>();
                datos.setearConsulta("Select Id, Descripcion from ELEMENTOS");
                datos.ejecutarLector();

                while (datos.Lector.Read())
                {
                    Elemento aux = new Elemento();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    listaElementos.Add(aux);
                }
                
                return listaElementos;      
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {   
                datos.cerrarConexion();          
            }

       }
    }
}

