using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using System.Net.Http.Headers;
using System.Collections;


namespace Negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> listar() 
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {

                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT P.Id ,P.Numero, P.Nombre, P.Descripcion, E.Descripcion AS Tipo, D.Descripcion AS Debilidad, P.UrlImagen, P.IdTipo, P.IdDebilidad FROM POKEMONS AS P, ELEMENTOS AS E , ELEMENTOS AS D WHERE P.IdTipo = e.Id AND D.Id = P.IdDebilidad AND Activo = 1";
                comando.Connection = conexion;


                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)lector["Id"];
                    aux.Numero = lector.GetInt32(1); // metodo uno
                    aux.Nombre = (string)lector["Nombre"]; // metodo dos
                    aux.Descripcion = (string)lector["Descripcion"];

                    //if (!lector.IsDBNull(lector.GetOrdinal("UrlImagen")))
                    //    aux.UrlImagen = (string)lector["UrlImagen"];

                    if (!(lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)lector["UrlImagen"];

                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)lector["idTipo"];
                    aux.Tipo.Descripcion = (string)lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)lector["idDebilidad"];
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];

                    lista.Add(aux);
                }
                
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

        }

        public void agregar (Pokemon nuevo)
        {   
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO POKEMONS (Numero, Nombre, Descripcion, Activo, idTipo, idDebilidad, UrlImagen) VALUES (" + nuevo.Numero + ",'" + nuevo.Nombre + "','" + nuevo.Descripcion + "',1, @idTipo, @idDebilidad, @UrlImagen)");
                datos.setearParametro("@idTipo",nuevo.Tipo.Id);
                datos.setearParametro("@idDebilidad", nuevo.Debilidad.Id);
                datos.setearParametro("@UrlImagen", nuevo.UrlImagen);
                datos.ejecutarAccion();
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

        public void modificar(Pokemon poke) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE POKEMONS SET Numero = @Numero, Nombre = @Nombre, Descripcion = @Descripcion, UrlImagen = @UrlImagen, IdTipo = @idTipo, IdDebilidad = @idDebilidad WHERE id = @id");
                datos.setearParametro("@Numero", poke.Numero);
                datos.setearParametro("@Nombre", poke.Nombre);
                datos.setearParametro("@Descripcion", poke.Descripcion);
                datos.setearParametro("@Urlimagen", poke.UrlImagen);
                datos.setearParametro("@idTipo", poke.Tipo.Id);
                datos.setearParametro("@idDebilidad", poke.Debilidad.Id);
                datos.setearParametro("@id", poke.Id);

                datos.ejecutarAccion();

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

        public void eliminarFisico(int Id) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM POKEMONS WHERE ID = @Id");
                datos.setearParametro("@Id", Id);
                datos.ejecutarAccion();

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

        public void eliminarLogico(int Id)        
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE POKEMONS SET Activo = 0 WHERE ID = @Id");
                datos.setearParametro("@Id", Id);
                datos.ejecutarAccion();
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

        public List<Pokemon> filtrar(string campo, string criterio, string filtro)
        {
            List<Pokemon> pokemons = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT P.Id ,P.Numero, P.Nombre, P.Descripcion, E.Descripcion AS Tipo, D.Descripcion AS Debilidad, P.UrlImagen, P.IdTipo, P.IdDebilidad FROM POKEMONS AS P, ELEMENTOS AS E , ELEMENTOS AS D WHERE P.IdTipo = e.Id AND D.Id = P.IdDebilidad AND Activo = 1 AND";

                if (campo == "Número")
                {
                    switch (criterio)
                    {
                        case "Mayor o igual que":
                            consulta += $" P.Numero >= {filtro}";
                            break;

                        case "Menor o igual que":
                            consulta += $" P.Numero <= {filtro}";
                            break;

                        case "Igual que":
                            consulta += $" P.Numero = {filtro}";
                            break;
                        default:
                            break;
                    }
                }
                else if (campo == "Nombre" || campo == "Descripcion")
                {
                    switch (criterio)
                    {
                        case "Empieza con":
                            consulta += $" P.{campo} LIKE '{filtro}%'";
                            break;
                        case "Termina con":
                            consulta += $" P.{campo} LIKE '%{filtro}'";
                            break;
                        case "Contiene":
                            consulta += $" P.{campo} LIKE '%{filtro}%'";
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLector();

                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = (int)datos.Lector["Numero"];
                    aux.Nombre = (string)datos.Lector["Nombre"]; // metodo dos
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];

                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)datos.Lector["idTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)datos.Lector["idDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

                    pokemons.Add(aux);
                }
                return pokemons;
              
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
