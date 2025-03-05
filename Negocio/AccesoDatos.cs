using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Negocio
{
    public class AccesoDatos //Creamos esta clase que tiene a su vez metodos para que conectarse a la BD desde otras clases sea mas facil con dichos metodos
    {
        private SqlConnection conexion; //Son atributos de la clase Acceso a datos de  tipo sqlConnection.
        private SqlCommand comando; //Idem arriba.
        private SqlDataReader lector;

        public SqlDataReader Lector //Como sqlDataReader es private tengo que crear la property esto para poder leerla. Para poder leer el lector desde el exterior, solo leerlo.
        {
            get { return lector; }
        }


        public AccesoDatos()
        { //Este es el constructor del objeto. Tendremos 2 objetos, uno comando y otro conexion.
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security= true"); //Es otra manera de conectarse diferente a la anterior.
            comando = new SqlCommand();

        }

        public void setearConsulta(string consulta)
        { //Es un metodo o funcion para realizar la accion de pedir la consulta y poner la consulta a realizar.
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta; //Aqui le paso la consulta por paramentro en el llamante.
        }

        public void ejecutarLectura() //Metodo que realiza la lectura de la respuesta de la consulta y la guarda en el lector
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

     
        public void ejecutarAccion()


        { //Es un metodo para ejecutar la accion de insertar un pokemon, es decir insertar una "No consulta"

            comando.Connection = conexion;
           

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery(); // Esto es lo importante y es diferente al lector executereader.
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
            
        public void setearParametro(string nombre, object valor ) //Funcion para validar los parametros que creo en la clase pokemonNegocio (en la consulta para renderizar los pokemons). Recibo los parametros precisamente por parametros
        {

            comando.Parameters.AddWithValue(nombre, valor);

        }

        public void cerrarConexion()
        {

            if (lector != null) //Si hay algo para leer se cierra el lector
            {
                lector.Close(); //Aca se cierra
                conexion.Close(); //Se cierra la conexion
            }
        } 
    }
}