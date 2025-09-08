using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoDatos
    {
        
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        //constructor

        public AccesoDatos() 
        {
            conexion = new SqlConnection("");
            comando = new SqlCommand();
        }
        
        // metodos

        public void setearConsulta(string consulta) 
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;                    
        }

        public void ejecutarLector() 
        {
            comando.Connection = conexion;
            try
            {                
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex )
            {

                throw ex;
            }
                    
        }
        
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex )
            {

                throw ex;
            }            
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);   
        }
        
        public void cerrarConexion() 
        {   
            if(lector != null)
                lector.Close();

            conexion.Close();
        }
    }
}



