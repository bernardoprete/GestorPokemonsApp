using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using negocio;

namespace Negocio 
{  

    // IMPORTANTE ----- Voy a tener 2 clases una llamada elementoNegocio y otro POkemonNegocio para diversificar responsabilidades y poder manejar de manera independientes los elementos, de las otras caracteristicas del pokemon como nombre num etc , Esto sirve tmb para hacerm as escalable la app. 
    public class ElementoNegocio // Desde esta clase me voy a conectar a la bd mediante los metodos creados en la clase acceso de datos. Es decir de una manera mas facil y corta.
    {
        public List<Elemento> listar() // Es un metodo de tipo lista de elementos. Me va a devolver una lista de elementos. Este metodo es distinto al listar que lista pokemons, este lista elementos.
        {

            List<Elemento> lista = new List<Elemento>(); //Creo como en pokemon negocio una lista, ya que el metodo va a devolver una lista porque es de clase listElemento.
            AccesoDatos datos = new AccesoDatos(); // Creo el objeto datos y con esto ya que tiene instancias tengo toda la primera parte de la conexion preparada. Este objeto tiene comando y lector y tiene la cadena de conexion configurada. 
            try
            {
                datos.setearConsulta("select Id , Descripcion from ELEMENTOS"); //  llAMANTE DEL METODO SETEAR CONSULTA CON PASAJE DE LA CONSULTA POR PARAMETRO. En esta consulta voy a pedir el ID y la descripcion del tipo de elemento.
                datos.ejecutarLectura(); // LLAMANTE DE LA FUNCION O METODO EJECUTAR LECTURA.

                while (datos.Lector.Read()) //Mientras haya algo para leer sigue en el while, esa es la condicion
                {

                    Elemento aux = new Elemento();
                    aux.id = (int)datos.Lector["Id"]; //Cargo el dato de la columna id haciendo un nuevo objeto llamado aux y parseando ya que se que el dato es un int
                    aux.Descripcion =(string)datos.Lector["Descripcion"];   
                    
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
                datos.cerrarConexion();
            }
        }
    }
}
