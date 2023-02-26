using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace negocio
{
    public class AccesoDatos
    {//basico para leer datos
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector//leer
        {
            get { return lector; }
        }
        public AccesoDatos()//acceso
        {
            conexion = new SqlConnection("server=DESKTOP-H342I2C\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true");
            comando = new SqlCommand();
        }
        public void setearConsulta(string consulta)//modificar
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void ejecutarAccion()//creacion de metodo que permite realizar la querry en la base de datos , se usa en pokemonNegocio
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                throw ex;
            }


        }



        public void cerrarConexion()
        {
            if(lector!= null)
                lector.Close();
            conexion.Close();
        }

        internal void setearParametro(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        internal void setearParametro(string v, int numero)
        {
            throw new NotImplementedException();
        }
    }

   




}
