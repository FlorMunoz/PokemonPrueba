using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Collections;

namespace negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> listar()
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();//obejos creados para establecer la conexion tipo conextada
            SqlCommand comando = new SqlCommand();//obejos creados para establecer la conexion tipo conextada
            SqlDataReader lector;//obejos creados para establecer la conexion tipo conextada




            try
            {
                //configuracion de cadena de conexion
                conexion.ConnectionString = "server=DESKTOP-H342I2C\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, P.IdTipo, P.Id from POKEMONS P, ELEMENTOS E where E.Id = P.Numero And P.Activo = 1";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                //transforma la lista en objetos
                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)lector["Id"];
                    aux.Numero = lector.GetInt32(0);
                    aux.Nombre = (String)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    //validacion para que lea la url sin tirar error en NULL
                    //if(!(lector.IsDBNull(lector.GetOrdinal("UrlImagen"))))
                      //  aux.UrlImagen = (string)lector["UrlImagen"];// quiero que muestre la imagen
                    //otra forma de validar la linea anterior
                    if (!(lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)lector["UrlImagen"];

                    aux.Tipo = new Elemento();//instancia para TIPO
                    aux.Tipo.Id = (int)lector["Id"];
                    aux.Tipo.Descripcion = (string)lector["Descripcion"];//necesita una instancia porque sino da null

                    lista.Add(aux);


                }
                //cuando termina de leer los datos de la tabla
                conexion.Close();
                return lista;

            }
            catch (Exception ex)// si ahi un error va a entrar aca
            {

                throw ex;
            }
        }

        public void agregar(Pokemon nuevo)//desarrollamos la parte logica del agregado nuevo osea el metodo de insercion
        {


            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into POKEMONS (Numero, Nombre, Descripcion, Activo, UrlImagen)values('" + nuevo.Numero + "', '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', 1, @urlImagen)");
                datos.setearParametro("@urlImagen", nuevo.UrlImagen);
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
        public void modificar(Pokemon poke)//logica para modificar
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update POKEMONS set Numero = @numero, Nombre = @nombre, Descripcion = @desc, UrlImagen = @img, IdTipo = @idTipo Where Id = @id");
                datos.setearParametro("@numero", poke.Numero);
                datos.setearParametro("@nombre", poke.Nombre);
                datos.setearParametro("@desc", poke.Descripcion);
                datos.setearParametro("@img", poke.UrlImagen);
                datos.setearParametro("@idTipo", poke.Tipo.Id);
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

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from pokemons where id = @id");
                datos.setearParametro("@id",id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR6-0S-edC81w_ZPXpUBd5lGD5S7YnKN1mjqA&usqp=CAU
        
        public void eliminarLogico(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("update POKEMONS set Activo = 0 Where id = @id");
                datos.setearParametro("@id" ,id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Pokemon> filtrar(string campo, string criterio, string filtro)//logica del filtro avanzado, realiza la consulta a la BD
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos(); 
            try
            {
                string consulta = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, P.IdTipo, P.Id from POKEMONS P, ELEMENTOS E where E.Id = P.Numero And P.Activo = 1 And ";
              if (campo == "Numero")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Numero > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Numero < " + filtro;
                            break;
                        default:
                            consulta = "Numero = " + filtro;
                            break;
                    }
                }
              else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like ' " + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta = "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
              else
                {
                    switch(criterio)
                    {
                        case "Comienza con":
                            consulta += "P.Descripcion like ' " + filtro + "%' ";
                        break;
                        case "Termina con":
                            consulta += "P.Descripcion like '%" + filtro + "'";
                        break;
                        default:
                            consulta = "P.Descripcion like '%" + filtro + "%'";
                        break;
                    }
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = datos.Lector.GetInt32(0);
                    aux.Nombre = (String)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    //validacion para que lea la url sin tirar error en NULL
                    //if(!(lector.IsDBNull(lector.GetOrdinal("UrlImagen"))))
                    //  aux.UrlImagen = (string)lector["UrlImagen"];// quiero que muestre la imagen
                    //otra forma de validar la linea anterior
                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];

                    aux.Tipo = new Elemento();//instancia para TIPO
                    aux.Tipo.Id = (int)datos.Lector["Id"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Descripcion"];//necesita una instancia porque sino da null

                    lista.Add(aux);


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
